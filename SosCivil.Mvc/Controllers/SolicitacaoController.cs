using Microsoft.AspNetCore.Mvc;

namespace SosCivil.Mvc.Controllers
{
    public class SolicitacaoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
