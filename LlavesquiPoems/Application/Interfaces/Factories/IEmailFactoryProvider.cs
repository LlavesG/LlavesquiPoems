using LlavesquiPoems.Application.Models.Enums;

namespace LlavesquiPoems.Application.Interfaces.Factories;

public interface IEmailFactoryProvider
{
    IEmailFactory GetFactory(EmailType type);
}