namespace Wooza.Telephony.Repository.Model
{
    public class Plan
    {
        public long PlanId { get; set; }
        public long Mininutes { get; set; }
        public long InternetFranchise { get; set; }
        public int Amount { get; set; }
        public  PlanType  PlanType{ get; set; }
        public string PlanOperator { get; set; }
    }
}
