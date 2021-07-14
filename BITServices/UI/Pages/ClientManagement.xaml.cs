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
using BITServices.ViewModels;

namespace BITServices.UI.Pages
{
    /// <summary>
    /// Interaction logic for ClientManagement.xaml
    /// </summary>
    public partial class ClientManagement : Page
    {
        public ClientManagement()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            UI.Windows.NewClientWindow newClientWindow = new UI.Windows.NewClientWindow();
            newClientWindow.Show();
        }

        private void btnDeny_Click(object sender, RoutedEventArgs e)
        {
            popSaveChanges.IsOpen = false;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = new ClientManagementViewModel();
        }
    }
}
