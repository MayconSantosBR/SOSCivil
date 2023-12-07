using Microsoft.AspNetCore.Mvc;
using SosCivil.Api.Data.Enums;
using SosCivil.Mvc.Models;
using SosCivil.Mvc.Service.Interfaces;

namespace SosCivil.Mvc.Controllers
{
    public class EntregaController : Controller
    {
        private readonly IRequestService _requestService;

        public EntregaController(IRequestService requestService)
        {
            _requestService = requestService;
        }

        public async Task<IActionResult> Index()
        {
            var entrega = await _requestService.PegarEntregasAssincrono();
            if (entrega.FirstOrDefault() != null && entrega.Any())
                entrega.FirstOrDefault().Solicitacao = new Solicitacao() { Id = 1};
            ViewData["Entregas"] = entrega;
            return View();
        }

        public IActionResult Novo()
        {
            ViewData["Acao"] = "Novo";

            var model = new Entrega();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Novo(Entrega model)
        {
            await _requestService.CriarEntregaAssincrono(model);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Editar(long id)
        {
            ViewData["Acao"] = "EditarItem";

            var model = await _requestService.PegarEntregaPorIdAssincrono(id);
            return View("Novo", model);
        }

        [HttpPost]
        public async Task<IActionResult> EditarItem(Entrega model)
        {
            await _requestService.EditarEntregaAssincrono(model);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Excluir(long id)
        {
            await _requestService.ExcluirEntregaAssincrono(id);
            return RedirectToAction("Index");
        }
    }
}
