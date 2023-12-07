using Microsoft.AspNetCore.Mvc;
using SosCivil.Api.Data.Enums;
using SosCivil.Mvc.Models;
using SosCivil.Mvc.Service;
using SosCivil.Mvc.Service.Interfaces;

namespace SosCivil.Mvc.Controllers
{
    public class SolicitacaoController : Controller
    {
        private readonly ISolicitacaoService _solicitacaoService;
        private readonly IItemService _itemService;
        public SolicitacaoController(ISolicitacaoService solicitacaoService, IItemService itemService)
        {
            _solicitacaoService = solicitacaoService;
            _itemService = itemService;
        }
        public async Task<IActionResult> Index()
        {
            var solicitacoes = await _solicitacaoService.GetAllSolicitacoes();
            ViewData["Solicitacoes"] = solicitacoes;
            return View();
        }

        public async Task<IActionResult> Novo()
        {
            var model = new Solicitacao();
            ViewData["Suprimentos"] = await _itemService.PegarSuprimentosAssincrono();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Novo(Solicitacao model)
        {
            var res = await _solicitacaoService.Create(model);
            return View("Index");
        }

        public IActionResult Editar(long id)
        {
            var model = new Solicitacao
            {
                Id = 1,
                NomeSolicitante = "João da Silva",
                CpfCnpjSolicitante = "123.456.789-00",
                Celular = "(11) 9 9999-9999",
                Rua = "Rua dos Bobos",
                Bairro = "Bairro dos Bobos",
                Cep = "99999-999",
                Status = StatusEnum.Delivered,
                DataSolicitacao = DateTime.Now,
                Suprimento = new Suprimento
                {
                    Id = 1,
                    Nome = "Água"
                }
            };
            return View("Novo", model);
        }
    }
}
