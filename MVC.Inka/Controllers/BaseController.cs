using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using NaskaInsaat.Controllers.Services;
using System.Globalization;

public class BaseController : Controller
{
    private readonly LocalizationService _localizer;

    public BaseController(LocalizationService localizer)
    {
        _localizer = localizer;
    }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        ViewBag.T = new Func<string, string>(key =>
        {
            var culture = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
            return _localizer.Translate(key, culture);
        });

        base.OnActionExecuting(context);
    }
}