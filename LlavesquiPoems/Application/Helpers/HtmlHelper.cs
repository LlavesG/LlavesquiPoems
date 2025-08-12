using LlavesquiPoems.Application.Dtos;
using LlavesquiPoems.Domain.Entities;

namespace LlavesquiPoems.Application.Helpers;

public static class HtmlHelper
{
 public static string GetHtmlVerificado(UserDto user)
        {
            string result = $@"<div><table><tbody ><tr><tdstyle=""padding:35px35px0"">
                    <tablewidth=""100%""border=""0""cellspacing=""0""cellpadding=""0"">
                    <div style=""background-color:black; margin-bottom:="""" 10%="""">
                    <img src= data:image/png;base64,{EncodeFileHelper.GetBase64File("/Recours/images/logo.png")} alt=""LogoMibPubr""class=""CToWUd""/></td>
                    </div><br>
                    <tdstyle=""padding:35px35px0"">
                    <tablewidth=""100%""border=""0""cellspacing=""0""cellpadding=""0"">
                        </tablewidth=""100%""border=""0""cellspacing=""0""cellpadding=""0""></tdstyle=""padding:35px35px0""><tdstyle=""padding:0030px;font-size:0pt;line-height:0pt;text-align:center""><imgsrc=""https: ci6.googleusercontent.com="""" proxy="""" z2p0ny6t2ekuicchxi2sloetqs97rnqy7e6n41-m452czfsiovgb8its8p0w3mm_8we3g3btxbumuoxbk1zj2sve9apnmh62r9fcf5rnbs3emvsvy3mlzltr91lfcvi=""s0-d-e1-ft#https://marketing-images.gotinder.com/3d7c06f59dcf45558d19d0e284c88091/0.jpg&quot;border=&quot;0&quot;width=&quot;39&quot;height=&quot;45&quot;alt=&quot;LogoMibPubr&quot;class=&quot;CToWUd&quot;"">
                        </imgsrc=""https:></tdstyle=""padding:0030px;font-size:0pt;line-height:0pt;text-align:center""><tdstyle=""padding-bottom:30px"">
                        <tablewidth=""100%""border=""0""cellspacing=""0""cellpadding=""0"">
                        </tablewidth=""100%""border=""0""cellspacing=""0""cellpadding=""0""></tdstyle=""padding-bottom:30px""><div><tdstyle=""padding-top:42px;-bottom:42px;border-bottom:2pxsolid#e5e5e5"">
                        <divstyle=""color:#35d337;font-family:'montserrat',arial,sans-serif;font-size:44px;line-height:48px;text-align:center;font-weight:bold"">
                        <spanstyle=""color:#f34ff33;text-decoration:none""> {user?.Name} {user.LastName} Su cuenta ha sido Validada
                        
                        </spanstyle=""color:#f34ff33;text-decoration:none""></divstyle=""color:#35d337;font-family:'montserrat',arial,sans-serif;font-size:44px;line-height:48px;text-align:center;font-weight:bold""></tdstyle=""padding-top:42px;-bottom:42px;border-bottom:2pxsolid#e5e5e5""></div>
                        <table><tbody><tr></tr></tbody><tbody>
                        <tr>
                        </tr>
                        <tr>
                        </tr></tbody><tbody>
                        <tr>
                        </tr>
                        </tbody>
                        </table> 
                        <tdstyle=""padding:030px"">
                        <tablewidth=""100%""border=""0""cellspacing=""0""cellpadding=""0"">
                        <tdstyle=""padding-bottom:30px"">
                        <divstyle=""color:#4c4c4c;font-family:'montserrat',arial,sans-serif;font-size:14px;line-height:20px;text-align:center"">
                        Ya puede cerrar esta ventana.
                        </divstyle=""color:#4c4c4c;font-family:'montserrat',arial,sans-serif;font-size:14px;line-height:20px;text-align:center""></tdstyle=""padding-bottom:30px""></tablewidth=""100%""border=""0""cellspacing=""0""cellpadding=""0""></tdstyle=""padding:030px""></tbody>
                        </table></td></tr></tbody></table></div>";
            return result;
        }
        public static string GetBodyValidateEmail(UserDto user, string tokenVal, string guid)
        {
            string body = "";
            string bodyHear = $@"<td style=""padding: 35px 35px 0"" class=""m_ - 1663463166135411564p20 - 15 - 0""> 
                     <table width = ""100%"" border = ""0"" cellspacing = ""0"" cellpadding = ""0
                             <tbody>
                              <tr>
                               <td style = ""padding:0 0 30px;font-size:0pt;line-height:0pt;text-align:center"" class=""m_-1663463166135411564pb-20"">
                    <img src= ""cid:{guid}"" alt=""LogoMibPubr""class=""CToWUd""/>
                    <br>
                    </td> 
                </tr> 
                 
                 
                <tr> 
                 <td style = ""padding-bottom:30px"" class=""m_-1663463166135411564pb-25""> 
                  <table width = ""100%"" border=""0"" cellspacing=""0"" cellpadding=""0""> 
                   <tbody>
                    <tr> 
                     <td style = ""padding-bottom:42px;border-bottom:2px solid #e5e5e5"" class=""m_-1663463166135411564pb-20""> 
                      <div class=""m_-1663463166135411564h1-c"" style=""color:#35d337;font-family:'Montserrat',Arial,sans-serif;font-size:44px;line-height:48px;text-align:center;font-weight:bold"">
                       <span style = ""color:#f34FF33;text-decoration:none"" > Verifica tu correo electrónico</span>
                      </div> </td> 
                    </tr> 
                   </tbody>
                  </table> </td> 
                </tr> 
                 
                 
                <tr> 
                 <td style = ""padding:0 30px"" class=""m_-1663463166135411564p0-10""> 
                  <table width = ""100%"" border=""0"" cellspacing=""0"" cellpadding=""0""> 
                   <tbody>
                    <tr> 
                     <td style = ""padding-bottom:30px"" >
                      <div style=""color:#4c4c4c;font-family:'Montserrat',Arial,sans-serif;font-size:14px;line-height:20px;text-align:center"">
                       Por favor {user.Name} {user.LastName}, verifica tu correo electrónico para asegurar tu cuenta.
                      </div> </td> 
                    </tr> 
                   </tbody>
                  </table> </td> 
                </tr> 
                 
                 
                <tr> 
                 <td style = ""padding:0 0 30px"" align=""center"" class=""m_-1663463166135411564pb-50""> 
                  <table border = ""0"" cellspacing=""0"" cellpadding=""0""> 
                   <tbody>
                    <tr> 
                     <td class=""m_-1663463166135411564text-button"" style=""border-radius:30px;padding:15px 30px;color:#ffffff;font-family:'Montserrat',Arial,sans-serif;font-size:14px;line-height:18px;text-align:center;letter-spacing:2px;text-transform:uppercase"" bgcolor=""##35d337"">";
            string bodyButton = @"<a href = """ + GetValidationURL(tokenVal) + @"a=" + GetTokenHtml(tokenVal) + @""" rel=""noopener noreferrer"" style=""color:#ffffff;text-decoration:none"" data-remote=""true""  data-saferedirecturl=""" + GetTokenHtml(tokenVal) + "";

            string bodytext = @"><span style = ""color:#ffffff;text-decoration:none""> VERIFICAR AHORA</span></a></td></tr> 
                   </tbody>
                  </table> </td> 
                </tr> 
                 
                <tr> 
                 <td style = ""padding-bottom:30px"" class=""m_-1663463166135411564pb-25""> 
                  <div style = ""color:#4c4c4c;font-family:'Montserrat',Arial,sans-serif;font-size:14px;line-height:20px;text-align:center"" >
                   O pega este enlace en tu navegador:";
            string bodyLink = @"<a href = """ + GetValidationURL(tokenVal) + @"a=" + GetTokenHtml(tokenVal) + "data-remote=\"true\"";
            string bodyTextLink = @"rel =""noopener noreferrer"" data-remote=""true"" data-saferedirecturl=""+GetValidationURL(tokenVal)+"">";
            string bodyFotther = @"<span style = ""color:#3;text-decoration:none"" >  " + GetValidationURL(tokenVal) + @"a=" + GetTokenHtml(tokenVal) + " </span></a>";
            string footer = @"</div> </td> 
                </tr> 
                 </tbody>
              </table> </td>";





            return body + bodyHear + bodyButton + bodytext + bodyLink + bodyTextLink + bodyFotther + footer;
        }

        public static string GetBodyValidatedEmail(UserDto user, string guid)
        {
            string body = "";
            string bodyHear = $@"<td style=""padding: 35px 35px 0"" class=""m_ - 1663463166135411564p20 - 15 - 0""> 
                     <table width = ""100%"" border = ""0"" cellspacing = ""0"" cellpadding = ""0
                             <tbody>
                              <tr>
                               <td style = ""padding:0 0 30px;font-size:0pt;line-height:0pt;text-align:center"" class=""m_-1663463166135411564pb-20"">
                               <div>
                               <img src= ""cid:{guid}"" alt=""LogoMibPubr""class=""CToWUd""/>
                                <br>
                            </div> </td> 
                </tr> 
                 
                 
                <tr> 
                 <td style = ""padding-bottom:30px"" class=""m_-1663463166135411564pb-25""> 
                  <table width = ""100%"" border=""0"" cellspacing=""0"" cellpadding=""0""> 
                   <tbody>
                    <tr> 
                     <td style = ""padding-bottom:42px;border-bottom:2px solid #e5e5e5"" class=""m_-1663463166135411564pb-20""> 
                      <div class=""m_-1663463166135411564h1-c"" style=""color:#35d337;font-family:'Montserrat',Arial,sans-serif;font-size:44px;line-height:48px;text-align:center;font-weight:bold"">
                       <span style = ""color:#f34FF33;text-decoration:none"" >Su cuenta ha sido verificada</span>
                      </div> </td> 
                    </tr> 
                   </tbody>
                  </table> </td> 
                </tr> 
                 
                 
                <tr> 
                 <td style = ""padding:0 30px"" class=""m_-1663463166135411564p0-10""> 
                  <table width = ""100%"" border=""0"" cellspacing=""0"" cellpadding=""0""> 
                   <tbody>
                    <tr> 
                     <td style = ""padding-bottom:30px"" >
                      <div style=""color:#4c4c4c;font-family:'Montserrat',Arial,sans-serif;font-size:14px;line-height:20px;text-align:center"">";
            string bodyHear2 = @" muchas gracias por verificar su cuenta, disfrute de todas las ventajas.
                      </div> </td> 
                    </tr> 
                   </tbody>
                  </table> </td> 
                </tr> 
                 
                 
                <tr> 
                 <td style = ""padding:0 0 30px"" align=""center"" class=""m_-1663463166135411564pb-50""> 
                  <table border = ""0"" cellspacing=""0"" cellpadding=""0""> ";


            string footer = @"</div> </td> 
                </tr> 
                 </tbody>
              </table> </td>";

            return body + bodyHear + user.UserName + bodyHear2 + footer;
        }
      
        private static string GetValidationURL(string token)
        {
            string result = @"https://localhost:5001/Valdiate?";
            return result;
        }
        private static string GetTokenHtml(string token)
        {
            //return token.Substring(1, token.Length - 2);
            return token;
        }
    }