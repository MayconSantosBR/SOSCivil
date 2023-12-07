using Microsoft.AspNetCore.Mvc;
using SosCivil.Api.Data.Enums;
using SosCivil.Mvc.Models;

namespace SosCivil.Mvc.Controllers
{
    public class EntregaController : Controller
    {
        public IActionResult Index()
        {
            var entregas = new List<Entrega>
            {
                new Entrega
                {
                    Id = 1,
                    Solicitacao = new Solicitacao
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
                    },
                    Status = StatusEnum.Delivered,
                    DataEntrega = DateTime.Now
                },
                new Entrega
                {
                    Id = 2,
                    Solicitacao = new Solicitacao
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
                            Nome = "Alimento"
                        }
                    },
                    Status = StatusEnum.Shipping,
                    DataEntrega = DateTime.Now
                },
                new Entrega
                {
                    Id = 3,
                    Solicitacao = new Solicitacao
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
                            Nome = "Remédio"
                        }
                    },
                    Status = StatusEnum.Approved,
                    DataEntrega = DateTime.Now
                }
            };
            ViewData["Entregas"] = entregas;
            return View();
        }

        public IActionResult Novo()
        {
            var model = new Entrega();
            ViewData["Solicitacoes"] = new List<Solicitacao>
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
                        Nome = "Água"
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
                        Nome = "Alimento"
                    }
                },
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Novo(Entrega model)
        {
            return View(model);
        }

        public IActionResult Editar(long id)
        {
            var model = new Entrega
            {
                Id = 1,
                Solicitacao = new Solicitacao
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
                },
                Status = StatusEnum.Delivered,
                DataEntrega = DateTime.Now
            };
            return View("Novo", model);
        }
    }
}
