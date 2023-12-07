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
        public IActionResult Index(bool show = false, string url = null)
        {
            ViewData["show"] = show;

            ViewData["url"] = string.IsNullOrEmpty(url) ? string.Empty : url;

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

                return RedirectToAction("Index", "Documento", new
                {
                    show = true,
                    url = url
                });
            }
            catch
            {
                return View("Index");
            }

        }

    }
}
