using Microsoft.AspNetCore.Mvc;

namespace SosCivil.Mvc.Controllers
{
    public class DocumentoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
