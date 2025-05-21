using ScheduleTracker.WPF.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ScheduleTracker.WPF.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public ICommand LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(Nav);
        }

        public void Nav(object obj)
        {
            // Assume login logic here
            bool isLoginSuccessful = true;

            if (isLoginSuccessful)
            {
                NavigationService.NavigateTo(new HomePage()); // Navigate after login
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
