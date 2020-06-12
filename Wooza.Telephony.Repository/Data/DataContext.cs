using Microsoft.EntityFrameworkCore;
using Wooza.Telephony.Model.Model;

namespace Wooza.Telephony.Repository.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
        }

        public DbSet<PlanType> PlanTypes { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<PlanOperator> PlanOperator { get; set; }

    }
}
