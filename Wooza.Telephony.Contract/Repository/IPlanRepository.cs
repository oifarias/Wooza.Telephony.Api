using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wooza.Telephony.Model.Model;

namespace Wooza.Telephony.Contract.Repository
{
    public interface IPlanRepository
    {
        Task NewPlan(Plan req);
    }
}
