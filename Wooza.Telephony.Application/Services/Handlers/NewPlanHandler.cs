using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Wooza.Telephony.Application.Services.Handlers.Model;
using Wooza.Telephony.Contract.Repository;
using Wooza.Telephony.Model.Model;

namespace Wooza.Telephony.Application.Services.Handlers
{
    public class NewPlanHandler : IRequestHandler<NewPlanRequest, NewPlanResponse>
    {
        private readonly IPlanRepository _planRepository;

        public NewPlanHandler(IPlanRepository planRepository)
        {
            _planRepository = planRepository;
        }

        public async Task<NewPlanResponse> Handle(NewPlanRequest request, CancellationToken cancellationToken)
        {
            var newPlan = new Plan
            {
                TypeId = 1,
                Amount = request.Amount,
                InternetFranchise = request.InternetFranchise,
                Mininutes = request.Mininutes,
                OperatorId = request.PlanOperator.GetHashCode(),
                PlanOperator = new PlanOperator
                { IdOperator = request.PlanOperator.GetHashCode(), NameOperator = request.PlanOperator.ToString() },
                PlanId = request.PlanId,
                PlanType = new PlanType { IdType = request.PlanType.GetHashCode(), Type = request.PlanType.ToString() }
            };
            await _planRepository.NewPlan(newPlan);
            return new NewPlanResponse();
        }

    }
}
