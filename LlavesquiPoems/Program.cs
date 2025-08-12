using System.Linq;
using System.Reflection;
using System.Text;
using LlavesquiPoems.Application.Configurations;
using LlavesquiPoems.Application.Interfaces.Factories;
using LlavesquiPoems.Application.Interfaces.IRepositories;
using LlavesquiPoems.Application.Interfaces.IRepository;
using LlavesquiPoems.Application.Interfaces.IService;
using LlavesquiPoems.Application.Interfaces.Repositories;
using LlavesquiPoems.Application.Interfaces.Validations.Exceptions;
using LlavesquiPoems.Application.Services;
using LlavesquiPoems.Application.Services.Factories.Users;
using LlavesquiPoems.Application.Services.Sessions;
using LlavesquiPoems.Infrastructure;
using LlavesquiPoems.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Setup PostgreSQL
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));
builder.Services.Configure<SmtpConfiguration>(builder.Configuration.GetSection("SmtpConfig"));
builder.Services.Configure<EncodeConfiguration>(builder.Configuration.GetSection("EncodeConfig"));
// Add controllers
builder.Services.AddControllers();

// Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register Repositories and Services by convention
var assembly = Assembly.GetExecutingAssembly();

var typesWithInterfaces = assembly.GetTypes()
    .Where(t =>
        t.IsClass &&
        !t.IsAbstract &&
        t.Namespace != null &&
        (t.Namespace.StartsWith("Repositories") || t.Namespace.StartsWith("Services"))
    )
    .Select(t => new
    {
        Impl = t,
        Interface = t.GetInterfaces().FirstOrDefault(i =>
            i.Name == "I" + t.Name &&
            i.Namespace != null &&
            (i.Namespace.StartsWith("IRepositories") || i.Namespace.StartsWith("IServices"))
        )
    })
    .Where(x => x.Interface != null);

foreach (var item in typesWithInterfaces)
{
    builder.Services.AddScoped(item.Interface, item.Impl);
}

builder.Services.AddScoped<IRecitalRepository, RecitalRepository>();
builder.Services.AddScoped<IRecitalService, RecitalService>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IUsersService, UserService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IEmailFactory, EmailCreatedFactory>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IQuizzesService, QuizzesService>();
builder.Services.AddScoped<ISessionService, SessionService>();
builder.Services.AddMvc()
    .AddMvcOptions(o => { o.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter()); });
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
        options.SlidingExpiration = true;
        options.AccessDeniedPath = "/Home/Forbidden";
        options.LoginPath = "/Identity/Account/Login";
    });

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowMyFrontend",
        builder =>
        {
            builder.WithOrigins("http://localhost:3000") // Cambia por la URL de tu frontend
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "LlavesquiPoems.API",
        Version = "v1",
        Description = "The LlavesquiPoems Service HTTP API"
    });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});


var app = builder.Build();

// Swagger UI only in development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseHttpsRedirection();
builder.Services.AddAuthorization();
app.UseCors("AllowMyFrontend");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();