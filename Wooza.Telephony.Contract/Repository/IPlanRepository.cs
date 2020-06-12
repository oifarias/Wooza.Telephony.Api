using System.Collections.Generic;
using System.Threading.Tasks;
using Wooza.Telephony.Model.Model;

namespace Wooza.Telephony.Contract.Repository
{
    public interface IPlanRepository
    {
         Task<string> NewPlanAsync(Plan req);
        Task<Plan> GetByIdAsync(long planId);
        Task<string> UpdatePlanAsync(Plan req);
        Task<string> DeletePlanAsync(long planId);
        Task<List<Plan>> ListPlansAsync();

    }
}
