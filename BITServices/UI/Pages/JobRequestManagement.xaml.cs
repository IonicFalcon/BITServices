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
using BITServices.Models;
using BITServices.UI.Windows;

namespace BITServices.UI.Pages
{
    /// <summary>
    /// Interaction logic for JobRequestManagement.xaml
    /// </summary>
    public partial class JobRequestManagement : Page
    {
        public JobRequestManagement()
        {
            InitializeComponent();
        }

        private void btnCreateRequest_Click(object sender, RoutedEventArgs e)
        {
            UI.Windows.CreateJobRequestWindow createJobRequestWindow = new UI.Windows.CreateJobRequestWindow();
            createJobRequestWindow.Show();
        }

        private void btnEditRequest_Click(object sender, RoutedEventArgs e)
        {
            EditJobRequestWindow editJobRequestWindow = new EditJobRequestWindow();
            if(((dynamic)DataContext).SelectedJob != null)
            {
                ((EditJobRequestViewModel)editJobRequestWindow.DataContext).EditJob = ((dynamic)DataContext).SelectedJob;
                ((EditJobRequestViewModel)editJobRequestWindow.DataContext).ClientID = ((dynamic)DataContext).SelectedJob.JobClient.ClientID;
            }

            editJobRequestWindow.Show();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = new JobRequestManagementViewModel();
        }

    }
}
