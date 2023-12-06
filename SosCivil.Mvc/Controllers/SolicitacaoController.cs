using Microsoft.AspNetCore.Mvc;
using SosCivil.Api.Data.Enums;
using SosCivil.Mvc.Models;

namespace SosCivil.Mvc.Controllers
{
    public class SolicitacaoController : Controller
    {
        public IActionResult Index()
        {
            var solicitacoes = new List<Solicitacao>
            {
                new Solicitacao
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
                        NomeItem = "Água"
                    }
                },
                new Solicitacao
                {
                    Id = 2,
                    NomeSolicitante = "Maria da Silva",
                    CpfCnpjSolicitante = "123.456.789-00",
                    Celular = "(11) 9 9999-9999",
                    Rua = "Rua dos Bobos",
                    Bairro = "Bairro dos Bobos",
                    Cep = "99999-999",
                    Status = StatusEnum.Shipping,
                    DataSolicitacao = DateTime.Now,
                    Suprimento = new Suprimento
                    {
                        Id = 2,
                        NomeItem = "Alimento"
                    }
                },
                new Solicitacao
                {
                    Id = 3,
                    NomeSolicitante = "José da Silva",
                    CpfCnpjSolicitante = "123.456.789-00",
                    Celular = "(11) 9 9999-9999",
                    Rua = "Rua dos Bobos",
                    Bairro = "Bairro dos Bobos",
                    Cep = "99999-999",
                    Status = StatusEnum.Approved,
                    DataSolicitacao = DateTime.Now,
                    Suprimento = new Suprimento
                    {
                        Id = 3,
                        NomeItem = "Remédio"
                    }
                }
            };
            ViewData["Solicitacoes"] = solicitacoes;
            return View();
        }

        public IActionResult Novo()
        {
            var model = new Solicitacao();
            ViewData["Suprimentos"] = new List<Suprimento>
            {
                new Suprimento
                {
                    Id = 1,
                    NomeItem = "Água"
                },
                new Suprimento
                {
                    Id = 2,
                    NomeItem = "Alimento"
                },
                new Suprimento
                {
                    Id = 3,
                    NomeItem = "Remédio"
                }
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Novo(Solicitacao model)
        {
            return View(model);
        }
    }
}
