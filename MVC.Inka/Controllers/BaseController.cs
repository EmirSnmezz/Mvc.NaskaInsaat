using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using NaskaInsaat.Controllers.Services;
using System.Globalization;

public class BaseController : Controller
{
    private readonly LocalizationService _localizer;
    private readonly string _language;
    public BaseController(LocalizationService localizer, string language)
    {
        _localizer = localizer;
        _language = language;
    }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        ViewBag.T = new Func<string, string>(key =>
        {
            var culture = _language;
            return _localizer.Translate(key, culture);
        });

        base.OnActionExecuting(context);
    }
}