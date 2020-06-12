using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Wooza.Telephony.Model.Model
{
    public class PlanOperator
    {
        [Key]
        public int IdOperator { get; set; }
        public string NameOperator { get; set; }
    }
}
