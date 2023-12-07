using FluentResults;
using Microsoft.AspNetCore.Mvc;
using SosCivil.Api.Controllers.Base;
using SosCivil.Api.Models.Dtos.Controllers;
using SosCivil.Api.Services;
using SosCivil.Api.Services.Interfaces;

namespace SosCivil.Api.Controllers
{
    [ApiController]
    [Route("api/")]
    public class PersonController : SosCivilControllerBase
    {
        private readonly IPersonService _personService;
        private readonly IUserService _userService;

        public PersonController(IPersonService personService, IUserService userService)
        {
            _personService = personService;
            _userService = userService;
        }


        [Route("persons")]
        [HttpGet]
        public async Task<ActionResult> All()
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

        [Route("persons")]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] PersonDto person, [FromQuery]string token, [FromQuery] string email)
        {
            try
            {
                var personEntity = await _personService.CreateAndReturn(person);
                var userDto = new UserDto
                {
                    Username = person.Name,
                    Password = token
                };
                var userResponse = ValidateServiceResponse(await _userService.CreateAsync(userDto, email, personEntity));
                return userResponse;
            }
            catch (Exception e)
            {
                return BadRequest(Result.Fail(e.Message));
            }
        }

        [Route("persons/{id}")]
        [HttpGet]
        public async Task<ActionResult> Get(long id)
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

        [Route("persons/{id}")]
        [HttpPut]
        public async Task<ActionResult> Update([FromRoute] long id, [FromBody] PersonDto person)
        {
            try
            {
                return ValidateServiceResponse(await _personService.MapAndUpdateAsync(id, person));
            }
            catch (Exception e)
            {
                return BadRequest(Result.Fail(e.Message));
            }
        }

        [Route("persons/{id}")]
        [HttpDelete]
        public async Task<ActionResult> Delete(long id)
        {
            try
            {
                return ValidateServiceResponse(await _personService.RemoveAsync(id));
            }
            catch (Exception e)
            {
                return BadRequest(Result.Fail(e.Message));
            }
        }
    }
}
