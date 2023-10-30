using Microsoft.AspNetCore.Mvc;

namespace SosCivil.Mvc.Controllers
{
    public class MeuPerfilController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
