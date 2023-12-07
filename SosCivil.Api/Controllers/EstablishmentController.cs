using FluentResults;
using Microsoft.AspNetCore.Mvc;
using SosCivil.Api.Controllers.Base;
using SosCivil.Api.Data.Entities;
using SosCivil.Api.Models.Dtos.Controllers;
using SosCivil.Api.Services;
using SosCivil.Api.Services.Interfaces;

namespace SosCivil.Api.Controllers
{
    [ApiController]
    [Route("api/")]
    public class EstablishmentController : SosCivilControllerBase
    {
        private readonly IEstablishmentService _establishmentService;
        private readonly IPersonService _personService;

        public EstablishmentController(IEstablishmentService establishmentService, IPersonService personService)
        {
            _establishmentService = establishmentService;
            _personService = personService;
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

        [Route("establishments")]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] EstablishmentDto establishment)
        {
            try
            {
                var persons = await _personService.GetAllAsync();
                var person = persons.Value.FirstOrDefault();
                establishment.PersonId = person.Id;
                return ValidateServiceResponse(await _establishmentService.MapAndCreateAsync(establishment));
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

        [Route("establishments/{id}")]
        [HttpPut]
        public async Task<ActionResult> Update(long id, [FromBody] EstablishmentDto establishment)
        {
            try
            {
                return ValidateServiceResponse(await _establishmentService.MapAndUpdateAsync(id, establishment));
            }
            catch (Exception e)
            {
                return BadRequest(Result.Fail(e.Message));
            }
        }

        [Route("establishments/{id}")]
        [HttpDelete]
        public async Task<ActionResult> Delete(long id)
        {
            try
            {
                return ValidateServiceResponse(await _establishmentService.RemoveAsync(id));
            }
            catch (Exception e)
            {
                return BadRequest(Result.Fail(e.Message));
            }
        }
    }
}
