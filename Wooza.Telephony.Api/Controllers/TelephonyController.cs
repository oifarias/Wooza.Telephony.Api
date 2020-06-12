using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using System.Threading.Tasks;
using Wooza.Telephony.Api.Controllers.ErroResponse;
using Wooza.Telephony.Application.Services.Handlers.Model;
using Wooza.Telephony.Application.Services.Handlers.Commands.PutPlan;
using Wooza.Telephony.Application.Services.Handlers.Commands.DeletePlan;
using System.Collections.Generic;
using Wooza.Telephony.Model.Model;
using Wooza.Telephony.Application.Services.Handlers.Commands.ListPlan;

namespace Wooza.Telephony.Api.Controllers
{
    public class TelephonyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TelephonyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("api/telephony/new-plan")]
        public async Task<IActionResult>NewPlan([FromBody]NewPlanRequest request)
        {
            try
            {
                var response = await _mediator.Send(request);
                return Ok(response);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPut("api/telephony/{PlanId}")]
        public async Task<IActionResult> UpdatePlan([FromBody] UpdatePlanRequest request)
        {
            try
            {
                var response = await _mediator.Send(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpDelete("api/telephony/{PlanId}")]
        public async Task<IActionResult> DeletePlan(long PlanId)
        {
            try
            {
                var response = await _mediator.Send(new DeletePlanRequest() { PlanId = PlanId});
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet("api/telephony/List")]
        public async Task<ActionResult<List<Plan>>> ListPlan()
        {
            try
            {
                var response = await _mediator.Send(new ListPlansRequest() {});
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
