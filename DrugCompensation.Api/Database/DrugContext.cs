using DrugCompensation.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace DrugCompensation.Api.Database
{
    public class DrugContext : DbContext
    {
        public DbSet<Drug> Drugs { get; set; }
        public DbSet<Compensation> Compensations { get; set; }
        public DbSet<CompensationRecord> CompensationRecords { get; set; }


        public DrugContext(DbContextOptions<DrugContext> options) : base(options)
        {
        }
    }
}
