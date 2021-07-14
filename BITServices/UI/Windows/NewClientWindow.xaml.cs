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
using System.Windows.Shapes;
using BITServices.ViewModels;

namespace BITServices.UI.Windows
{
    /// <summary>
    /// Interaction logic for NewClientWindow.xaml
    /// </summary>
    public partial class NewClientWindow : Window
    {
        public NewClientWindow()
        {
            InitializeComponent();
            DataContext = new NewClientViewModel();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void pswPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if(DataContext != null)
            {
                ((dynamic)DataContext).Password = ((PasswordBox)sender).Password;
            }
        }

        private void pswCheck_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if(DataContext != null)
            {
                ((dynamic)DataContext).PasswordCheck = ((PasswordBox)sender).Password;
            }
        }
    }
}
