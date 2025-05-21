using Microsoft.EntityFrameworkCore;
using ScheduleTracker.Domain.Models;

namespace ScheduleTracker.EntityFamework
{
    public class ScheduleTrackerDbContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Scheduling> Scheduling { get; set; }

        public ScheduleTrackerDbContext(DbContextOptions options) : base(options){ }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Scheduling>().OwnsOne(a=>a.ScheduleType);

            base.OnModelCreating(modelBuilder);
        }
    }
}
