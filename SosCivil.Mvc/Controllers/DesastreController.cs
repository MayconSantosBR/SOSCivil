using Microsoft.AspNetCore.Mvc;

namespace SosCivil.Mvc.Controllers
{
    public class DesastreController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
