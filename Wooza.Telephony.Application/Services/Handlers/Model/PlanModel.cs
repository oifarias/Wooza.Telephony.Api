using System;
using System.Collections.Generic;
using System.Text;
using Wooza.Telephony.Application.Services.Handlers.Model.Enum;

namespace Wooza.Telephony.Application.Services.Handlers.Model
{
    public class PlanModel
    {
        public long PlanId { get; set; }
        public long Mininutes { get; set; }
        public long InternetFranchise { get; set; }
        public int Amount { get; set; }
        public TypeEnum PlanType { get; set;}
        public OperatorEnum PlanOperator { get; set; }
    }
}
