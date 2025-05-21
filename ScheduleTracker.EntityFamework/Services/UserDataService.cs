using Microsoft.EntityFrameworkCore;
using ScheduleTracker.Domain.Models;
using ScheduleTracker.EntityFamework;
using ScheduleTracker.EntityFramework;

public class UserDataService
{
    private readonly ScheduleTrackerDbContextFactory _dbContextFactory;

    public UserDataService(ScheduleTrackerDbContextFactory dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }

    public async Task UpdateProfilePicture(int userId, string imagePath)
    {
        using var context = _dbContextFactory.CreateDbContext();

        var user = await context.Users.FirstOrDefaultAsync(u => u.Id == userId);
        if (user == null)
        {
            throw new InvalidOperationException("User not found.");
        }

        user.ProfileImage = imagePath;

        await context.SaveChangesAsync();
    }

    public async Task<string> GetProfilePictureByUserId(int userId)
    {
        using var context = _dbContextFactory.CreateDbContext();

        // Retrieve the user from the database by ID
        var user = await context.Users.FirstOrDefaultAsync(u => u.Id == userId);
        return user?.ProfileImage; // Return null if the user doesn't exist or doesn't have a profile picture
    }

    public async Task<string> GetUsernameById(int id)
    {
        using (ScheduleTrackerDbContext context = _dbContextFactory.CreateDbContext())
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Id == id);
            return user?.Username;
        }
    }
}
