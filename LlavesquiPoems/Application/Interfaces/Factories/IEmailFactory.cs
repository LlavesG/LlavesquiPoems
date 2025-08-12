using System.Net.Mail;
using LlavesquiPoems.Application.Dtos;

namespace LlavesquiPoems.Application.Interfaces.Factories;

public interface IEmailFactory
{
    MailMessage CreateUser(UserDto user);
}