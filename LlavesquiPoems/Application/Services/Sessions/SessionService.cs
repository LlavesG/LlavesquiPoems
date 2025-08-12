using LlavesquiPoems.Application.Models;

namespace LlavesquiPoems.Application.Services.Sessions;

public class SessionService:ISessionService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public SessionService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public Session? CurrentSession()
    {
        return _httpContextAccessor.HttpContext?.Items["Session"] as Session;
    }
}