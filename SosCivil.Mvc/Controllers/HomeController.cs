using Microsoft.AspNetCore.Mvc;
using SosCivil.Mvc.Extensions;
using SosCivil.Mvc.Models;
using System.Diagnostics;

namespace SosCivil.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUser _user;

        public HomeController(ILogger<HomeController> logger, IUser user)
        {
            _logger = logger;
            _user = user;
        }

        public IActionResult Index()
        {
            if(!_user.EstaAutenticado())
                return RedirectToAction("Login","Auth");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}