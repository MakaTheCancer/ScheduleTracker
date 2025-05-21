using ScheduleTracker.Domain.Models;
using ScheduleTracker.Domain.Services;
using ScheduleTracker.EntityFramework;
using ScheduleTracker.EntityFramework.Services;

namespace ConsoleApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {


            // Create the factory
            var dbContextFactory = new ScheduleTrackerDbContextFactory();

            // Create the service for User
            var userService = new GenericDataService<User>(dbContextFactory);

            // Create a new user
            var newUser = new User
            {
                Email = "admin@example.com",
                Username = "admin",
                Password = "1234", // NOTE: Store hashed passwords in real apps!
                DateJoined = DateTime.Now,
                ProfileImage = null
            };

            // Save it to the database
            var createdUser = await userService.Delete(10);
            //Console.WriteLine($"User created with ID: {createdUser.Id}");

            //new User(update)
        }
    }
}
