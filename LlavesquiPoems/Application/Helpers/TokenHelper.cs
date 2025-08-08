using System.Security.Claims;
using System.Text;
using LlavesquiPoems.Application.Configurations;
using LlavesquiPoems.Application.Dtos;
using LlavesquiPoems.Application.Models;
using Microsoft.AspNetCore.Authentication;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using System.Threading.Tasks;
using System.Net;
using Microsoft.Extensions.Options;
using System.Linq.Expressions;
using Microsoft.Extensions.Configuration;
namespace LlavesquiPoems.Application.Helpers;

public class TokenHelper {
    
        private readonly EncodeConfiguration _encodeConfig;

        public TokenHelper(EncodeConfiguration encodeConfig)
        {
            _encodeConfig = encodeConfig;
        }

       
        public  string BuildTokenUser(UserDto user, int? ttl)
        {

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_encodeConfig.tokenKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()), new Claim("userName", user.UserName.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(ttl ?? 30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }


        public  async Task<Session?> GetSesionAsync(HttpContext context)
        {
            var token = await GetBearerToken(context);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_encodeConfig.tokenKey);
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                Session session = new()
                {
                    Id = long.Parse(jwtToken.Claims.First(x => x.Type == "id").Value),
                    UserName = jwtToken.Claims.First(x => x.Type == "userName").Value
                };

                if (session.Id == 0 || string.IsNullOrEmpty(session.UserName)) return null;
                return session;
            }
            catch
            {
                return null;
            }
        }
        public async Task<bool> ValidateToken(HttpContext context)
        {
            var token = await GetBearerToken(context);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_encodeConfig.tokenKey);
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                Session session = new()
                {
                    Id = long.Parse(jwtToken.Claims.First(x => x.Type == "id").Value),
                    UserName = jwtToken.Claims.First(x => x.Type == "userName").Value
                };

                return session.Id != default && !string.IsNullOrEmpty(session.UserName);
            }
            catch
            {
                return false;
            }
        }

        

        public  Session GetSesion(string token)
        {
            if (token == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_encodeConfig.tokenKey);
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                Session session = new()
                {
                    Id = long.Parse(jwtToken.Claims.First(x => x.Type == "id").Value),
                    UserName = jwtToken.Claims.First(x => x.Type == "userName").Value
                };

                if (session.Id == default || string.IsNullOrEmpty(session.UserName)) return null;
                return session;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public UserDto GetUserWithToken( UserDto user)
        {
            
                user.Token = BuildTokenUser(user, 30);

                return user;
                
        }
        private static async Task<string> GetBearerToken(HttpContext context)
        {
            string token = await context.GetTokenAsync("access_token");
            if (context.Request.Headers.TryGetValue("Authorization", out var headerAuth))
            {
                var jwtToken = headerAuth.First().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[1];
                token = jwtToken.Trim();
            }

            return token;
        }
    }
   