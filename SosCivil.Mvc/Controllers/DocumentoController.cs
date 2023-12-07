using Microsoft.AspNetCore.Mvc;
using SosCivil.Mvc.Models;
using SosCivil.Mvc.Service;

namespace SosCivil.Mvc.Controllers
{
    public class DocumentoController : Controller
    {
        private readonly IDocumentoService _documentoService;
        public DocumentoController(IDocumentoService documentoService)
        {
            _documentoService = documentoService;
        }
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

        public async Task<IActionResult> Novo()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Novo(Documento doc, IFormFile file)
        {
            try
            {
                var url = await _documentoService.NovoDocumento(file);
                
                return View("Index");
            }
            catch
            {
                return View("Index");
            }

        }

    }
}
