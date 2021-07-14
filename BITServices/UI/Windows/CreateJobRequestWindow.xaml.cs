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
using BITServices.Models;


namespace BITServices.UI.Windows
{
    /// <summary>
    /// Interaction logic for CreateJobRequestWindow.xaml
    /// </summary>
    public partial class CreateJobRequestWindow : Window
    {
        public CreateJobRequestWindow()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = new CreateJobRequestViewModel();
        }

        private void CollectionViewSource_Filter(object sender, FilterEventArgs e)
        {
            Contractor contractor = e.Item as Contractor;

            if(contractor != null)
            {
                if (cmbJobSkill.SelectedIndex != -1)
                {

                    bool skillFound = false;

                    foreach (string skill in contractor.SkillList)
                    {
                        if (skill == cmbJobSkill.SelectedValue.ToString())
                        {
                            skillFound = true;
                            break;
                        }
                    }

                    if (!skillFound)
                    {
                        e.Accepted = false;
                    }
                    else
                    {
                        e.Accepted = true;
                    }
                }
                else
                {
                    e.Accepted = true;
                }
            }
        }

        private void cmbJobSkill_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ((CollectionViewSource)this.Resources["cvsAvaliableContractors"]).View.Refresh();
        }
    }
}
