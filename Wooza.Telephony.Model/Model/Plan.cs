using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Wooza.Telephony.Model.Model
{
    public class Plan
    {
        [Key]
        public long PlanId { get; set; }
        public long Mininutes { get; set; }
        public long InternetFranchise { get; set; }
        public int Amount { get; set; }
        public int TypeId { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatorio.")]
        public PlanType PlanType { get; set; }

        public int OperatorId { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatorio.")]
        public PlanOperator PlanOperator { get; set; }
    }
}
