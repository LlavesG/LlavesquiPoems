using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using LlavesquiPoems.Application.Configurations;
using LlavesquiPoems.Application.Dtos;

namespace LlavesquiPoems.Application.Helpers;

public class SmtpHelper
{
        private readonly SmtpConfiguration _config;

        public SmtpHelper(SmtpConfiguration config)
        {
            _config = config;
        }

        public  async Task SendEmail(MailMessage message)
        {

            message.IsBodyHtml = true;
            using var smtp = new SmtpClient
            {
                Credentials = new NetworkCredential(_config.UserName, _config.UserKey),
                Host = _config.Host,
                Port = _config.Port,
                EnableSsl = _config.EnabledSsl,
            };
            await smtp.SendMailAsync(message);
        }
        
        public  MailMessage CreateEmailValdate(UserDto user, string tokenVal)
        {
            LinkedResource res = new LinkedResource(EncodeFileHelper.GetUriFile("/Recours/images/logo.png"), MediaTypeNames.Image.Jpeg);

            res.ContentId = Guid.NewGuid().ToString();
            string htmlBody = HtmlHelper.GetBodyValidateEmail(user, tokenVal, res.ContentId);
            AlternateView avHtml = AlternateView.CreateAlternateViewFromString
              (htmlBody, null, MediaTypeNames.Text.Html);

            avHtml.LinkedResources.Add(res);
            MailMessage message = new MailMessage();

            message.AlternateViews.Add(avHtml);

            Attachment att = new Attachment(EncodeFileHelper.GetUriFile("/Recours/images/logo.png"));
            att.ContentDisposition.Inline = true;
            message.To.Add(new MailAddress("<" + user.Email.ToString() + ">"));
            message.From = new MailAddress("Mib Pubs <mibpubs@gmail.com>");

            message.Subject = GetSubjectemail();
            message.Body = htmlBody;
            message.IsBodyHtml = true;
            message.Attachments.Add(att);
            return message;
        }
        public  MailMessage CreateEmailValdated(UserDto user)
        {
            LinkedResource res = new LinkedResource(EncodeFileHelper.GetUriFile("/Recours/images/logo.png"), MediaTypeNames.Image.Jpeg);

            res.ContentId = Guid.NewGuid().ToString();
            string htmlBody = HtmlHelper.GetBodyValidatedEmail(user, res.ContentId);
            AlternateView avHtml = AlternateView.CreateAlternateViewFromString
              (htmlBody, null, MediaTypeNames.Text.Html);

            avHtml.LinkedResources.Add(res);
            MailMessage message = new MailMessage();
            message.AlternateViews.Add(avHtml);
            Attachment att = new Attachment(EncodeFileHelper.GetUriFile("/Recours/images/logo.png"));
            att.ContentDisposition.Inline = true;

            message.To.Add(new MailAddress("<" + user.Email.ToString() + ">"));
            message.From = new MailAddress("Mib Pubs <mibpubs@gmail.com>");

            message.Subject = GetSubjectemailValdiated();
            message.Body = htmlBody;
            message.IsBodyHtml = true;
            message.Attachments.Add(att);
            return message;
        }

        private  string GetSubjectemail()
        {
            string subject = "Verifica tu correo electrónico";
            return subject;
        }
        private  string GetSubjectemailValdiated()
        {
            string subject = "Cuenta Verificada";
            return subject;
        }

        private  string GetSubjectEmailResetPass()
        {
            string subject = "Reinicio de Contraseñas";
            return subject;
        }

}