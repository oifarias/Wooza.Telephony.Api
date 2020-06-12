using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Wooza.Telephony.Application.Services.Handlers.Commands.PutPlan;
using Wooza.Telephony.Application.Services.Handlers.Commands.UpdatePlan;
using Wooza.Telephony.Application.Services.Handlers.Model;
using Wooza.Telephony.Contract.Repository;
using Wooza.Telephony.Model.Model;

namespace Wooza.Telephony.Application.Services.Handlers
{
    public class PlanHandler : IRequestHandler<NewPlanRequest, NewPlanResponse>,
                               IRequestHandler<UpdatePlanRequest, UpdatePlanResponse>
    {
        private readonly IPlanRepository _planRepository;

        public PlanHandler(IPlanRepository planRepository)
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
            var response = await _planRepository.NewPlanAsync(newPlan);
            return new NewPlanResponse() { Response = response};
        }

        public async Task<UpdatePlanResponse> Handle(UpdatePlanRequest request, CancellationToken cancellationToken)
        {
            Plan getplan =await _planRepository.GetByIdAsync(request.PlanId);
            var update = new Plan
            {
                TypeId = request.PlanType.GetHashCode() == null ? getplan.TypeId : 0,
                Amount = request.Amount == null ? getplan.Amount : 0,
                InternetFranchise = request.InternetFranchise == null ? getplan.InternetFranchise : 0,
                Mininutes = request.Mininutes == null ? getplan.Mininutes : 0,
                OperatorId = request.PlanOperator.GetHashCode() == null ? getplan.PlanOperator.IdOperator : 0,
                PlanOperator = new PlanOperator
                { IdOperator = request.PlanOperator.GetHashCode() == null ? getplan.OperatorId : 0, NameOperator = request.PlanOperator.ToString()  == null ? getplan.PlanOperator.NameOperator : "" },
                PlanId = getplan.PlanId,
                PlanType = new PlanType { IdType = request.PlanType.GetHashCode() == null ? getplan.TypeId : 0, Type = request.PlanType.ToString() == null ? getplan.PlanType.Type : "" }
            };
            var response = await _planRepository.UpdatePlanAsync(update);
            return new UpdatePlanResponse() { Response = response };
        }

    }
}
