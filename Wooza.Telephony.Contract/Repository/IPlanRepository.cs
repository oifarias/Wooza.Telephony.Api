using System.Threading.Tasks;
using Wooza.Telephony.Model.Model;

namespace Wooza.Telephony.Contract.Repository
{
    public interface IPlanRepository
    {
         Task<string> NewPlanAsync(Plan req);
    }
}
