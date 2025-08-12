using Microsoft.AspNetCore.Mvc;

namespace LlavesquiPoems.Web.Midelwares;

public class ValidateLoginAttribute : TypeFilterAttribute
{
    public ValidateLoginAttribute() : base(typeof(ValidateLoginFilter))
    {
    }
}