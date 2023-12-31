﻿using FluentResults;
using Microsoft.AspNetCore.Mvc;
using SosCivil.Api.Controllers.Base;
using SosCivil.Api.Data.Entities;
using SosCivil.Api.Services;
using SosCivil.Api.Services.Interfaces;

namespace SosCivil.Api.Controllers
{
    [ApiController]
    [Route("api/")]
    public class CobradeController : SosCivilControllerBase
    {
        private readonly ICobradeService _cobradeService;

        public CobradeController(ICobradeService cobradeService)
        {
            _cobradeService = cobradeService;
        }

        [Route("cobrades")]
        [HttpGet]
        public async Task<ActionResult> All()
        {
            try
            {
                return ValidateServiceResponse(await _cobradeService.GetAllAsync());
            }
            catch (Exception e)
            {
                return BadRequest(Result.Fail(e.Message));
            }
        }

        [Route("cobrades/{id}")]
        [HttpGet]
        public async Task<ActionResult> Get(long id)
        {
            try
            {
                return ValidateServiceResponse(await _cobradeService.GetByIdAsync(id));
            }
            catch (Exception e)
            {
                return BadRequest(Result.Fail(e.Message));
            }
        }

        [Route("cobrades/sync")]
        [HttpPatch]
        public async Task<ActionResult> RequestCobradeTableSync()
        {
            try
            {
                return ValidateServiceResponse<List<Cobrade>>(await _cobradeService.CreateOrUpdateAsync());
            }
            catch (Exception e)
            {
                return BadRequest(Result.Fail(e.Message));
            }
        }
    }
}
