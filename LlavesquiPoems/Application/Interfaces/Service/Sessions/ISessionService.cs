using LlavesquiPoems.Application.Models;

namespace LlavesquiPoems.Application.Services.Sessions;

public interface ISessionService
{
    Session? CurrentSession();
}