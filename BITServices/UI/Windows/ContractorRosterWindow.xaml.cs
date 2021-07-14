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
    /// Interaction logic for ContractorRosterWindow.xaml
    /// </summary>
    public partial class ContractorRosterWindow : Window
    {
        public ContractorRosterWindow()
        {
            InitializeComponent();
            DataContext = new ContractorRosterViewModel();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            //Return the created roster back
            NewContractorWindow newContractor;
            foreach(Window window in Application.Current.Windows)
            {
                if(window.Title == "New Contractor")              //Find the new contractor window
                {
                    newContractor = (NewContractorWindow)window;
                    ((NewContractorViewModel)newContractor.DataContext).NewContractor.Roster = ((dynamic)DataContext).Roster;   //Set the roster
                    newContractor.BringIntoView();               //Bring it forward

                    break;
                }
            }

            this.Close();
        }
    }
}
