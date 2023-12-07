﻿using Microsoft.AspNetCore.Mvc;
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
                        Nome = "Remédio"
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
                    Nome = "Água"
                },
                new Suprimento
                {
                    Id = 2,
                    Nome = "Alimento"
                },
                new Suprimento
                {
                    Id = 3,
                    Nome = "Remédio"
                }
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Novo(Solicitacao model)
        {
            return View(model);
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
