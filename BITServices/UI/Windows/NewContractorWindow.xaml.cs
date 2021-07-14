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
    /// Interaction logic for NewContractorWindow.xaml
    /// </summary>
    public partial class NewContractorWindow : Window
    {
        public NewContractorWindow()
        {
            InitializeComponent();
            DataContext = new NewContractorViewModel();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAddSkill_Click(object sender, RoutedEventArgs e)
        {
            popSkills.IsOpen = true;
        }

        private void btnViewRoster_Click(object sender, RoutedEventArgs e)
        {
            //Send data forward
            ContractorRosterWindow contractorRosterWindow = new ContractorRosterWindow();
            if (((dynamic)DataContext).NewContractor.Roster != null)
            {
                ((ContractorRosterViewModel)contractorRosterWindow.DataContext).Roster = ((dynamic)DataContext).NewContractor.Roster;
            }
            contractorRosterWindow.Show();
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
