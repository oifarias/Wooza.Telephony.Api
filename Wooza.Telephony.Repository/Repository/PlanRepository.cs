using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Cryptography.X509Certificates;
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

        public  async Task<string> DeletePlanAsync(long planId)
        {
            Plan result = await GetByIdAsync(planId);
             _context.Plans.RemoveRange(result);
            return "plan successfully deleted";
        }

        public async Task<Plan> GetByIdAsync(long planId)
        {
            var req = new Plan() { PlanId = planId };
            return await _context.Plans.Include(x => x.PlanId).FirstOrDefaultAsync();
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

        public  async Task<string> UpdatePlanAsync (Plan req)
        {
            try
            {
                _context.Plans.Add(req);
                await _context.SaveChangesAsync();
                return "Updated Plan with success";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
