using LlavesquiPoems.Application.Interfaces.Factories;
using LlavesquiPoems.Application.Models.Enums;
using LlavesquiPoems.Application.Services.Factories.Users;

namespace LlavesquiPoems.Application.Services.Facotires;

public class EmailFactoryProvider
{
    private readonly IServiceProvider _serviceProvider;

    public EmailFactoryProvider(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IEmailFactory GetFactory(EmailType type)
    {
        return type switch
        {
            EmailType.Validation => _serviceProvider.GetRequiredService<EmailCreatedFactory>(),
            // EmailType.PasswordReset => _serviceProvider.GetRequiredService<PasswordResetEmailFactory>(),
            _ => throw new NotImplementedException()
        };
    }
}