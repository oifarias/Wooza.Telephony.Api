using MediatR;
using Wooza.Telephony.Application.Services.Handlers.Model.Enum;

namespace Wooza.Telephony.Application.Services.Handlers.Model
{
    public class NewPlanRequest : IRequest<NewPlanResponse>
    {
        public long PlanId { get; set; }
        public long Mininutes { get; set; }
        public long InternetFranchise { get; set; }
        public int Amount { get; set; }
        public TypeEnum PlanType { get; set; }
        public int DDD { get; set; }
        public OperatorEnum PlanOperator { get; set; }
    }
}
