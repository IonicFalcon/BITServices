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
using BITServices.Models;
using BITServices.ViewModels;

namespace BITServices.UI.Windows
{
    /// <summary>
    /// Interaction logic for EditJobRequestWindow.xaml
    /// </summary>
    public partial class EditJobRequestWindow : Window
    {
        public EditJobRequestWindow()
        {
            InitializeComponent();
            DataContext = new EditJobRequestViewModel();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CollectionViewSource_Filter(object sender, FilterEventArgs e)
        {
            Contractor contractor = e.Item as Contractor;

            if (contractor != null)
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
    }
}
