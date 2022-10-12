using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SavingOps.Models;

namespace SavingOps.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<SavingOps.Models.AccountSettings> AccountSettings { get; set; }
        public DbSet<SavingOps.Models.Bill> Bill { get; set; }
        public DbSet<SavingOps.Models.Fuel> Fuel { get; set; }
        public DbSet<SavingOps.Models.Rent> Rent { get; set; }
        public DbSet<SavingOps.Models.Saving> Saving { get; set; }
    }
}