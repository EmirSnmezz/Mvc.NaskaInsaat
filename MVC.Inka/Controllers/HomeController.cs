using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using NaskaInsaat.Controllers.Services;

namespace NaskaInsaat.Controllers
{
    public class HomeController : BaseController
    {
        private readonly LocalizationService _localizer;
        public HomeController(LocalizationService localizer) : base(localizer)
        {
            _localizer = localizer;
        }

        public IActionResult Index()
        {
            var menuTitle = _localizer.Translate("Home", "tr");
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
    }
}
