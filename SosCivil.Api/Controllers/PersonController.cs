using FluentResults;
using Microsoft.AspNetCore.Mvc;
using SosCivil.Api.Controllers.Base;
using SosCivil.Api.Data.Entities;
using SosCivil.Api.Repositories.Interfaces;
using SosCivil.Api.Services.Interfaces;
using ZstdSharp.Unsafe;

namespace SosCivil.Api.Controllers
{
    [ApiController]
    [Route("api/")]
    public class PersonController : SosCivilControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }


        [Route("persons")]
        [HttpGet]
        public async Task<ActionResult<Result>> All()
        {
            try
            {
                return ValidateServiceResponse(await _personService.GetAllAsync());
            }
            catch (Exception e)
            {
                return BadRequest(Result.Fail(e.Message));
            }
        }

        public async Task<ActionResult<Result>> Get(long id)
        {
            try
            {
                return ValidateServiceResponse(await _personService.GetByIdAsync(id));
            }
            catch (Exception e)
            {
                return BadRequest(Result.Fail(e.Message));
            }
        }

    }

}
