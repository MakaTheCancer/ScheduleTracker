
using Newtonsoft.Json;
using ScheduleTracker.Domain.Models;
using ScheduleTracker.EntityFramework.Services;
using ScheduleTracker.WPF.Services;
using ScheduleTracker.WPF.ViewModels;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using ScheduleTracker.EntityFramework.Services;
using ScheduleTracker.EntityFramework;



namespace ScheduleTracker.WPF.Controls
{
    /// <summary>
    /// Interaction logic for LogInNav.xaml
    /// </summary>
    public partial class LogInNav : UserControl
    {
        private readonly GenericDataService<User> _userService;
        public LogInNav()
        {
            InitializeComponent();
            _userService = new GenericDataService<User>(new ScheduleTrackerDbContextFactory());
        }



        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailTextBox.Text;
            string password = passwordtext.Text;

            var loginData = new
            {
                Email = email,
                Password = password
            };

            string json = JsonConvert.SerializeObject(loginData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) => true;

            using (HttpClient client = new HttpClient(handler))
            {
                try
                {
                    HttpResponseMessage response = await client.PostAsync("https://localhost:7200/api/auth/login", content);

                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        var userId = await _userService.GetUserIdByEmail(email);

                        if (userId == null)
                        {
                            MessageBox.Show("User ID not found for email.");
                            return;
                        }

                        CurrentUserService.SetUser(new CurrentUser
                        {
                            Id = (int)userId,
                            Email = email
                        });

                        MessageBox.Show("Login successful: " + result);
                        NavigationService.NavigateTo(new HomePage());
                    }
                    else
                    {
                        string error = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Login failed: " + error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Connection error: " + ex.Message);
                }
            }

        }

        private void EmailTextBox_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (EmailTextBox.Text == "Email Address")
                EmailTextBox.Clear();
        }

        private void passwordtext_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (passwordtext.Text == "Password")
                passwordtext.Clear();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.NavigateTo(new SignUp1());
        }
    }
}
