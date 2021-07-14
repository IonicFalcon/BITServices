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
using BITServices.DAL;
using BITServices.Models;
using BITServices.UI;

namespace BITServices.UI.Pages
{
    /// <summary>
    /// Interaction logic for WelcomePage.xaml
    /// </summary>
    public partial class WelcomePage : Page
    {
        public WelcomePage()
        {
            InitializeComponent();

        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if(EmployeeSQLHelper.GetEmployeeFromUsername(txtUsername.Text) == null)
            {
                return;
            }

            Employee employee = EmployeeSQLHelper.GetEmployeeFromUsername(txtUsername.Text);

            if (employee.Login(pswPassword.Password))
            {
                MainWindow window = (MainWindow)App.Current.MainWindow;
                window.LoggedInEmployee = employee;
            }
            else
            {
                MessageBox.Show("Incorrect username and password combination. Please try again", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }
    }
}
