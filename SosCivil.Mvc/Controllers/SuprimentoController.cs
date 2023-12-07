using Microsoft.AspNetCore.Mvc;
using SosCivil.Api.Data.Enums;
using SosCivil.Core.Data.Enums;
using SosCivil.Mvc.Models;

namespace SosCivil.Mvc.Controllers
{
    public class SuprimentoController : Controller
    {
        public IActionResult Index()
        {
            var suprimentos = new List<Suprimento>
            {
                new Suprimento {
                    Id = 1,
                    Nome = "Água",
                    Descricao = "Água potável",
                    Quantidade = 10,
                    QuantidadeTotal = 100,
                    UnidadeDeMedida = UnityOfMeasurementEnum.Liters,
                },
                new Suprimento
                {
                    Id = 2,
                    Nome = "Alimento",
                    Descricao = "Alimento não perecível",
                    Quantidade = 10,
                    QuantidadeTotal = 100,
                    UnidadeDeMedida = UnityOfMeasurementEnum.Kilograms,
                },
                new Suprimento
                {
                    Id = 3,
                    Nome = "Remédio",
                    Descricao = "Remédio para dor de cabeça",
                    Quantidade = 10,
                    QuantidadeTotal = 100,
                    UnidadeDeMedida = UnityOfMeasurementEnum.Unit,
                }
            };
            ViewData["Suprimentos"] = suprimentos;
            return View();
        }

        public IActionResult Novo()
        {
            var model = new Suprimento();
            return View(model);
        }

        [HttpPost]
        public IActionResult Novo(Suprimento model)
        {
            return View(model);
        }

        public IActionResult Editar(long id)
        {
            var model = new Suprimento
            {
                Id = 1,
                Nome = "Água",
                Descricao = "Água potável",
                Quantidade = 10,
                QuantidadeTotal = 100,
                UnidadeDeMedida = UnityOfMeasurementEnum.Liters,
            };
            return View("Novo", model);
        }
    }
}

