using MediatR;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Wooza.Telephony.Application.Services.Handlers.Commands.DeletePlan
{
   public  class DeletePlanRequest :IRequest<DeletePlanResponse>
    {
        public long PlanId { get; set; }
    }
}
