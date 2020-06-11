using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Wooza.Telephony.Application.Services.Handlers.Model;

namespace Wooza.Telephony.Application.Services.Handlers
{
    public class NewPlanHandler : IRequestHandler<NewPlanRequest, NewPlanResponse>
    { 
        public NewPlanHandler()
        {

        }

        public Task<NewPlanResponse> Handle(NewPlanRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

    }
}
