using System.Globalization;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using NaskaInsaat.Controllers.Services;

namespace NaskaInsaat.Controllers
{
    public class HomeController : BaseController
    {
        private readonly LocalizationService _localizer;
        public HomeController(LocalizationService localizer) : base(localizer,"tr")
        {
            _localizer = localizer;
        }

        public IActionResult Index()
        {
            var menuTitle = _localizer.Translate("tr","tr");
            ViewBag.T = menuTitle;

            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Projects()
        {
            return View();
        }

        public IActionResult Services()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Referances()
        {
            return View();
        }

        public IActionResult ChangeLanguage(string language)
        {
            Cookie cookie = new Cookie()
            {
                Name = "lang",
                Value = language ?? "en",
                Secure = true,
                HttpOnly = true,
                Expires = DateTime.Now.AddDays(1)
            };
            if(!(Request.Cookies.Any(p => p.Key == "lang" && p.Value == cookie.Value)))
            {
                Response.Cookies.Append(cookie.Name, cookie.Value);
            }

            return RedirectToAction("Index");
        }
    }
}
