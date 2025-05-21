using ScheduleTracker.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleTracker.WPF.Services
{
    public static class CurrentUserService
    {
        public static CurrentUser LoggedInUser { get; private set; }

        public static void SetUser(CurrentUser user)
        {
            LoggedInUser = user;
        }

        public static int GetUserId()
        {
            return LoggedInUser?.Id ?? throw new InvalidOperationException("No user is logged in.");
        }
    }


}
