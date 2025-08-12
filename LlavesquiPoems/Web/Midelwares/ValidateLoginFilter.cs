using LlavesquiPoems.Application.Configurations;
using LlavesquiPoems.Application.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;

namespace LlavesquiPoems.Web.Midelwares;

public class ValidateLoginFilter(IOptions<EncodeConfiguration> options) : IAsyncAuthorizationFilter
{
    private readonly TokenHelper _tokenHelper = new(options.Value);

    public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    {
        if (!await CheckToken(context.HttpContext))
        {
            context.Result = new UnauthorizedResult();
        } else{
            var session = await _tokenHelper.GetSesionAsync(context.HttpContext);
            context.HttpContext.Items["Session"] = session;
        }
    }
    private async  Task<bool> CheckToken(HttpContext context)
    {
        bool tv =await  _tokenHelper.ValidateToken(context);
        return tv;
    }

    public async void OnActionExecuting(ActionExecutingContext context)
    {
        if (!await CheckToken(context.HttpContext))
        {
            context.Result = new UnauthorizedResult();
        }
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
    }
}