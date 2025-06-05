using Microsoft.EntityFrameworkCore;
using Lab3BusDatabase.Infrastructure.Models;

namespace Lab3BusDatabase.Infrastructure
{
    public class BusDbContext : DbContext
    {
        public DbSet<BusModel> Buses { get; set; }
        public DbSet<DriverModel> Drivers { get; set; }

        public BusDbContext(DbContextOptions<BusDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BusModel>()
                .HasOne(b => b.Driver)
                .WithMany(d => d.Buses)
                .HasForeignKey(b => b.DriverId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
