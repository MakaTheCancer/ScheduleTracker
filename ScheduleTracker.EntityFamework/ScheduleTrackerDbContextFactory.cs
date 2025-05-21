using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;
using ScheduleTracker.EntityFamework;

namespace ScheduleTracker.EntityFramework
{
    public class ScheduleTrackerDbContextFactory : IDesignTimeDbContextFactory<ScheduleTrackerDbContext>
    {
        public ScheduleTrackerDbContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<ScheduleTrackerDbContext>();
            options.UseSqlServer("Server=(localdb)\\ProjectModels;Database=ScheduleTrackerDB;Trusted_Connection=True;TrustServerCertificate=True");

            return new ScheduleTrackerDbContext(options.Options);
        }
    }
}
