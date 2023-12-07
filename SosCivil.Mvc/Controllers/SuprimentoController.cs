using Microsoft.AspNetCore.Mvc;
using SosCivil.Api.Data.Enums;
using SosCivil.Core.Data.Enums;
using SosCivil.Mvc.Models;
using SosCivil.Mvc.Service.Interfaces;

namespace SosCivil.Mvc.Controllers
{
    public class SuprimentoController : Controller
    {
        private readonly IItemService _itemService;

        public SuprimentoController(IItemService itemService)
        {
            _itemService = itemService;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Suprimentos"] = await _itemService.PegarSuprimentosAssincrono();
            return View();
        }

        public IActionResult Novo()
        {
            ViewData["Acao"] = "Novo";

            var model = new Suprimento();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Novo(Suprimento model)
        {
            await _itemService.CriarSuprimentoAssincrono(model);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Editar(long id)
        {
            ViewData["Acao"] = "EditarItem";

            var model = await _itemService.PegarSuprimentoPorIdAssincrono(id);
            return View("Novo", model);
        }

        [HttpPost]
        public async Task<IActionResult> EditarItem(Suprimento model)
        {
            await _itemService.EditarSuprimentoAssincrono(model);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Excluir(long id)
        {
            await _itemService.ExcluirSuprimentoAssincrono(id);
            return RedirectToAction("Index");
        }
    }
}

