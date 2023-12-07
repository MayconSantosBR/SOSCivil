using Microsoft.AspNetCore.Mvc;
using SosCivil.Mvc.Models;

namespace SosCivil.Mvc.Controllers
{
    public class DocumentoController : Controller
    {
        public IActionResult Index()
        {
            var documentos = new List<Documento>();
            ViewData["Documentos"] = documentos;
            return View();
        }
        public IActionResult Excluir(long id)
        {
            
            return View();
        }
       
    }
}
