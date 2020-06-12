using System;
using System.Threading.Tasks;
using Wooza.Telephony.Contract.Repository;
using Wooza.Telephony.Model.Model;
using Wooza.Telephony.Repository.Data;

namespace Wooza.Telephony.Repository.Repository
{
    public class PlanRepository : IPlanRepository
    {
        private DataContext _context;

        public PlanRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<string> NewPlanAsync(Plan req)
        {
            try
            {
                 _context.Plans.Add(req);
                await _context.SaveChangesAsync();
                return "New Plan created witch succes";
            
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
    }
}
