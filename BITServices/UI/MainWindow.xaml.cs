using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BITServices.UI.Pages;
using BITServices.Models;
using BITServices.Control;
using System.ComponentModel;
using System.IO;

namespace BITServices
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private string _defaultProfilePicAddress = @"../../UI/Images/Portrait_Placeholder.png";
        private Employee _loggedInEmployee;
        private string _welcomeMessage;
        private BitmapImage _profilePic;
        public Employee LoggedInEmployee
        {
            get => _loggedInEmployee;
            set
            {
                if (value == null)
                {
                    WelcomeMessage = "Sign in to continue";
                    ProfilePic = ImageController.UriToBitmap(_defaultProfilePicAddress);
                    _loggedInEmployee = null;
                }
                else
                {
                    _loggedInEmployee = value;
                    WelcomeMessage = $"Welcome, {LoggedInEmployee.FirstName}";
                    
                    if(LoggedInEmployee.ProfilePicData != null)
                    {
                        ProfilePic = ImageController.ImageArrayToBitmap(LoggedInEmployee.ProfilePicData);
                    }
                }
                LogOnStateChanged();
            }
        }
        public string WelcomeMessage
        {
            get => _welcomeMessage;
            set
            {
                if (value != _welcomeMessage)
                {
                    _welcomeMessage = value;
                    OnPropertyChanged("WelcomeMessage");
                }
            }
        }

        public BitmapImage ProfilePic
        {
            get => _profilePic;
            set
            {
                if(value != _profilePic)
                {
                    _profilePic = value;
                    OnPropertyChanged("ProfilePic");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            MainContent.Content = new WelcomePage();

            if(LoggedInEmployee == null)
            {
                WelcomeMessage = "Sign in to continue";
                ProfilePic = ImageController.UriToBitmap(_defaultProfilePicAddress);
            }
        }

        private void radCoordinator_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new CoordinatorManagement();
        }

        private void radContractor_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new ContractorManagement();
        }

        private void radClient_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new ClientManagement();
        }

        private void radJobs_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new JobRequestManagement();
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Are you sure you wish to log out?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                LoggedInEmployee = null;
                chkAccountDetails.IsChecked = false;
            }
        }

        private void LogOnStateChanged()
        {
            if (LoggedInEmployee != null)
            {
                stkSidebar.IsEnabled = true;
                chkAccountDetails.Visibility = Visibility.Visible;

                switch (LoggedInEmployee.EmployeeType)
                {
                    case "Admin":
                        radCoordinator.IsEnabled = true;
                        break;
                    case "Coordinator":
                        radCoordinator.IsEnabled = false;
                        break;

                }

                MainContent.Content = new JobRequestManagement();
                radJobs.IsChecked = true;
            }
            else
            {
                stkSidebar.IsEnabled = false;
                chkAccountDetails.Visibility = Visibility.Hidden ;
                MainContent.Content = new WelcomePage();
                //stkProfileDropdown.Visibility = Visibility.Collapsed;
            }
        }

       

    }
}
