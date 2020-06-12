using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using System.Threading.Tasks;
using Wooza.Telephony.Api.Controllers.ErroResponse;
using Wooza.Telephony.Application.Services.Handlers.Model;

namespace Wooza.Telephony.Api.Controllers
{
    [Route("/api/telephony")]
    public class TelephonyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TelephonyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("/new-plan")]
        public async Task<IActionResult>NewPlan(NewPlanRequest request)
        {
            try
            {
                var response = await _mediator.Send(request);
                return Ok(response);
            }
            catch(ValidationException ex)
            {
                return BadRequest(ResponseError(ex));
            }
        }


        protected ErrorResponse ResponseError(ValidationException ex)
        {

            var response = new ErrorResponse();

            ex.Errors.ToList().ForEach(e =>
            {
                response.Validations.Add(new ErrorResponse.ErrorFieldMessage()
                {
                    Field = e.PropertyName.ToLower(),
                    Message = e.ErrorMessage
                });
            });

            return response;
        }
    }
}
