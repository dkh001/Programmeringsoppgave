using Innofactor.EfCoreJsonValueConverter;
using Microsoft.EntityFrameworkCore;
using Programmeringsoppgave.Models.Entities;

namespace Programmeringsoppgave.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<DailyMeasure>();
            builder.AddJsonFields();

        }
        public DbSet<DailyMeasure> DailyMeasure { get; set; }
    }

}
