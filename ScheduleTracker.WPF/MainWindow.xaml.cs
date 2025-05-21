
using ScheduleTracker.WPF.Services;
using System.Windows;



namespace ScheduleTracker.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            NavigationService.MainFrame = Main;
            Main.Navigate(new LogIn());

        }

        private int _pageIndex = 0;

        private void clickNext(object sender, RoutedEventArgs e)
        {
            _pageIndex = (_pageIndex + 1) % 3; // Loop from 0 → 1 → 2 → 0

            switch (_pageIndex)
            {
                case 0:
                    Main.Navigate(new LogIn());
                    break;
                case 1:
                    Main.Navigate(new HomePage());
                    break;
                case 2:
                    Main.Navigate(new SignUp1());
                    break;
            }
        }

    }
}