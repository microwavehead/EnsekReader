using Microsoft.EntityFrameworkCore;

namespace EnsekReader.API.Models.Database
{
    public class EnsekDbContext : DbContext
    {
        public EnsekDbContext(DbContextOptions<EnsekDbContext> options) : base(options)
        { }

        public DbSet<MeterReading> MeterReadings { get; set; }
        public DbSet<Account> Accounts { get; set; }
    }
}
