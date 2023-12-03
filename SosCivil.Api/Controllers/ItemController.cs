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
    public class ItemController : SosCivilControllerBase
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [Route("items")]
        [HttpGet]
        public async Task<ActionResult> All()
        {
            try
            {
                return ValidateServiceResponse(await _itemService.GetAllAsync());
            }
            catch (Exception e)
            {
                return BadRequest(Result.Fail(e.Message));
            }
        }

        [Route("items")]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] ItemDto itemDto)
        {
            try
            {
                return ValidateServiceResponse(await _itemService.MapAndCreateAsync(itemDto));
            }
            catch (Exception e)
            {
                return BadRequest(Result.Fail(e.Message));
            }
        }

        [Route("items/{id}")]
        [HttpGet]
        public async Task<ActionResult> Get(long id)
        {
            try
            {
                return ValidateServiceResponse(await _itemService.GetByIdAsync(id));
            }
            catch (Exception e)
            {
                return BadRequest(Result.Fail(e.Message));
            }
        }

        //[Route("items/{id}")]
        //[HttpPut]
        //public async Task<ActionResult> Update(long id, [FromBody] ItemDto itemDto)
        //{
        //    try
        //    {
        //        return ValidateServiceResponse(await _itemService.MapAndUpdateAsync(itemDto));
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(Result.Fail(e.Message));
        //    }
        //}
    }
}
