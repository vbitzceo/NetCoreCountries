using Microsoft.EntityFrameworkCore;
using voidBitz.NETCore.NetCoreCountries.Models;

namespace voidBitz.NETCore.NetCoreCountries.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Country> Country { get; set; }
        
        

    }
}
