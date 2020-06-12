using System.ComponentModel.DataAnnotations;

namespace Wooza.Telephony.Model.Model
{
    public class PlanType
    {
        [Key]
        public int IdType { get; set; }
        public string Type { get; set; }
    }
}
