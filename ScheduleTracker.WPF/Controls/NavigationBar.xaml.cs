using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using ScheduleTracker.WPF.Services;
using ScheduleTracker.EntityFramework.Services;
using Microsoft.EntityFrameworkCore.Internal;
using ScheduleTracker.Domain.Models;
using ScheduleTracker.EntityFramework;
using static System.Net.Mime.MediaTypeNames;

namespace ScheduleTracker.WPF.Controls
{
    /// <summary>
    /// Interaction logic for NavigationBar.xaml
    /// </summary>
    public partial class NavigationBar : UserControl
    {
        private readonly UserDataService _userDataService = new UserDataService(new ScheduleTrackerDbContextFactory());
        private int userId;
        public NavigationBar()
        {
            InitializeComponent();
            userId = CurrentUserService.GetUserId();
            


            // Call async initializer
            Loaded += NavigationBar_Loaded;

        }

        private async void NavigationBar_Loaded(object sender, RoutedEventArgs e)
        {
            string imagePath = await _userDataService.GetProfilePictureByUserId(userId);
            string username = await _userDataService.GetUsernameById(userId);

            if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
            {
                AvatarImage.Source = new BitmapImage(new Uri(imagePath, UriKind.Absolute));
            }

            Username.Text = username;

        }


        private void ClickCalendar(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("calendar");
        }

        private void ClickReminder(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("reminder");

        }

        private void ClickSettings(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("settings");

        }

        private void Upload(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("settings");

        }

        private async void ClickUploadPfp(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select Profile Image";
            openFileDialog.Filter = "Image Files (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg";

            if (openFileDialog.ShowDialog() == true)
            {
                string selectedFilePath = openFileDialog.FileName;

                // Show the image in the <Image> control
                AvatarImage.Source = new BitmapImage(new Uri(selectedFilePath));

                // Optional: Convert to byte[] to upload/store
                string imageData = selectedFilePath;
                // You can now upload this imageData to your backend or save it
                try
                {
                    await _userDataService.UpdateProfilePicture(userId, imageData);
                    MessageBox.Show("Profile picture updated successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }

            }
        }

    }
}
