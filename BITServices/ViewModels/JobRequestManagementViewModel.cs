using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using BITServices.Models;
using BITServices.Control;
using BITServices.DAL;
using System.Data;

namespace BITServices.ViewModels
{
    class JobRequestManagementViewModel : ViewModel
    {
        private Commander _deleteRequestCommand, _verifyRequestCommand;
        private ObservableCollection<Job> _jobCollection;
        private Job _selectedJob;

        public ObservableCollection<Job> JobCollection
        {
            get => _jobCollection;
            set
            {
                _jobCollection = value;
                OnPropertyChanged("JobCollection");
            }
        }
        public Job SelectedJob
        {
            get => _selectedJob;
            set
            {
                _selectedJob = value;
                OnPropertyChanged("SelectedJob");
            }
        }

        public Commander DeleteRequestCommand
        {
            get
            {
                if(_deleteRequestCommand == null)
                {
                    _deleteRequestCommand = new Commander(DeleteRequestMethod);
                }
                return _deleteRequestCommand;
            }
            set => _deleteRequestCommand = value;
        }
        public Commander VerifyRequestCommand
        {
            get
            {
                if(_verifyRequestCommand == null)
                {
                    _verifyRequestCommand = new Commander(VerifyRequestMethod);
                }
                return _verifyRequestCommand;
            }
            set => _verifyRequestCommand = value;
        }


        public JobRequestManagementViewModel()
        {
            RefreshDataGrid();
        }

        private void RefreshDataGrid()
        {
            SelectedJob = null;
            JobCollection = new ObservableCollection<Job>(JobSQLHelper.GetAllJobs());
        }

        private void DeleteRequestMethod()
        {
            if(MessageBox.Show("Are you sure you want to delete this job?\nThis cannot be undone.", "Delete Job", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                if(JobSQLHelper.DeleteJob(SelectedJob) == 1)
                {
                    MessageBox.Show("Job Successfully Deleted", "", MessageBoxButton.OK, MessageBoxImage.Information);
                    LogHelper.Log(LogTarget.EventLog, "Job Successfully Deleted");
                    RefreshDataGrid();
                }
                else
                {
                    MessageBox.Show("An Error Has Occured\nPlease try again.", "", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void VerifyRequestMethod()
        {
            if(MessageBox.Show("Are you sure you want to verify this job?", "Verify Job", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                if(SelectedJob.EndDateTime == null)
                {
                    MessageBox.Show("This job hasn't been completed.", "", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if(JobSQLHelper.VerifyJob(SelectedJob) == 1)
                {
                    MessageBox.Show("Job Successfully Verified", "", MessageBoxButton.OK, MessageBoxImage.Information);
                    LogHelper.Log(LogTarget.EventLog, "Job Successfully Verified");
                    RefreshDataGrid();
                }
                else
                {
                    MessageBox.Show("An Error Has Occured\nPlease try again.", "", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
