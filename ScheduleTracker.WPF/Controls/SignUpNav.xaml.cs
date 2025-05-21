using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ScheduleTracker.WPF.Services;


namespace ScheduleTracker.WPF.Controls
{
    /// <summary>
    /// Interaction logic for SignUpNav.xaml
    /// </summary>
    public partial class SignUpNav : UserControl
    {
        public SignUpNav()
        {
            InitializeComponent();
        }

        private async void Register_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailTextBox.Text;
            string password = passwordtext.Text;
            string User = Username.Text;

            var registrationData = new
            {
                Email = email,
                Password = password,
                Username = User
            };

            string json = JsonConvert.SerializeObject(registrationData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) => true;

            using (HttpClient client = new HttpClient(handler))
            {
                try
                {
                    HttpResponseMessage response = await client.PostAsync("https://localhost:7200/api/auth/register", content);

                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        
                        MessageBox.Show("Registration successful: " + result);
                        NavigationService.NavigateTo(new LogIn()); // redirect to login after registration
                    }
                    else
                    {
                        string error = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Registration failed: " + error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Connection error: " + ex.Message);
                }
            }
        }

        private void Username_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
                if(Username.Text == "Username")
                Username.Text = "";
        }

        private void EmailTextBox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(EmailTextBox.Text == "Email Address")
            EmailTextBox.Text = "";
        }

        private void passwordtext_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (passwordtext.Text == "Password")
                passwordtext.Text = "";
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.NavigateTo(new LogIn());
        }
    }
}
