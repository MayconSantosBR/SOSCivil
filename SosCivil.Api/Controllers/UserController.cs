using FluentResults;
using Microsoft.AspNetCore.Mvc;
using SosCivil.Api.Controllers.Base;
using SosCivil.Api.Models.Dtos.Controllers;
using SosCivil.Api.Services;

namespace SosCivil.Api.Controllers
{
    [ApiController]
    [Route("api/")]
    public class UserController : SosCivilControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("users")]
        [HttpGet]
        public async Task<ActionResult> All()
        {
            try
            {
                return ValidateServiceResponse(await _userService.GetAllAsync());
            }
            catch (Exception e)
            {
                return BadRequest(Result.Fail(e.Message));
            }
        }

        [Route("users")]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] UserDto user)
        {
            try
            {
                return ValidateServiceResponse(await _userService.MapAndCreateAsync(user));
            }
            catch (Exception e)
            {
                return BadRequest(Result.Fail(e.Message));
            }
        }

        [Route("users/{id}")]
        [HttpGet]
        public async Task<ActionResult> Get(long id)
        {
            try
            {
                return ValidateServiceResponse(await _userService.GetByIdAsync(id));
            }
            catch (Exception e)
            {
                return BadRequest(Result.Fail(e.Message));
            }
        }

        [Route("users/{id}")]
        [HttpPut]
        public async Task<ActionResult> Update(long id, [FromBody] UserDto user)
        {
            try
            {
                return ValidateServiceResponse(await _userService.MapAndUpdateAsync(id, user));
            }
            catch (Exception e)
            {
                return BadRequest(Result.Fail(e.Message));
            }
        }

        [Route("users/{id}")]
        [HttpDelete]
        public async Task<ActionResult> Delete(long id)
        {
            try
            {
                return ValidateServiceResponse(await _userService.RemoveAsync(id));
            }
            catch (Exception e)
            {
                return BadRequest(Result.Fail(e.Message));
            }
        }
    }
}
