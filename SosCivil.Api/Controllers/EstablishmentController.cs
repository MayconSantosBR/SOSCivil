using FluentResults;
using Microsoft.AspNetCore.Mvc;
using SosCivil.Api.Controllers.Base;
using SosCivil.Api.Data.Entities;
using SosCivil.Api.Services;
using SosCivil.Api.Services.Interfaces;

namespace SosCivil.Api.Controllers
{
    [ApiController]
    [Route("api/")]
    public class EstablishmentController : SosCivilControllerBase
    {
        private readonly IEstablishmentService _establishmentService;

        public EstablishmentController(IEstablishmentService establishmentService)
        {
            _establishmentService = establishmentService;
        }

        [Route("establishments")]
        [HttpGet]
        public async Task<ActionResult> All()
        {
            try
            {
                return ValidateServiceResponse(await _establishmentService.GetAllAsync());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("establishments/{id}")]
        [HttpGet]
        public async Task<ActionResult> Get(long id)
        {
            try
            {
                return ValidateServiceResponse(await _establishmentService.GetByIdAsync(id));
            }
            catch (Exception e)
            {
                return BadRequest(Result.Fail(e.Message));
            }
        }
    }
}
