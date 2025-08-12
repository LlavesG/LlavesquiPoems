using System.Net.Mail;
using System.Net.Mime;
using LlavesquiPoems.Application.Configurations;
using LlavesquiPoems.Application.Dtos;
using LlavesquiPoems.Application.Helpers;
using LlavesquiPoems.Application.Interfaces.Factories;
using Microsoft.Extensions.Options;

namespace LlavesquiPoems.Application.Services.Factories.Users;

public class EmailCreatedFactory() : IEmailFactory
{
    
    public MailMessage CreateUser(UserDto user)
    {
        LinkedResource res = new LinkedResource(EncodeFileHelper.GetUriFile("/Recours/images/logo.png"), MediaTypeNames.Image.Jpeg);

        res.ContentId = Guid.NewGuid().ToString();
        string htmlBody = HtmlHelper.GetBodyValidateEmail(user, user.Token, res.ContentId);
        AlternateView avHtml = AlternateView.CreateAlternateViewFromString
            (htmlBody, null, MediaTypeNames.Text.Html);

        avHtml.LinkedResources.Add(res);
        MailMessage message = new MailMessage();

        message.AlternateViews.Add(avHtml);

        Attachment att = new Attachment(EncodeFileHelper.GetUriFile("/Recours/images/logo.png"));
        att.ContentDisposition.Inline = true;
        message.To.Add(new MailAddress("<" + user.Email.ToString() + ">"));
        message.From = new MailAddress("Mib Pubs <mibpubs@gmail.com>");

        message.Subject = "Verifica tu correo electrónico";
        message.Body = htmlBody;
        message.IsBodyHtml = true;
        message.Attachments.Add(att);
        return message;
    }
}