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
    class CreateJobRequestViewModel : ViewModel
    {
        private Job _newJob;
        private ObservableCollection<Contractor> _avaliableContractors;
        private string _clientID;
        private Commander _createJobCommand;

        public List<string> SkillList { get; set; }
        public Job NewJob
        {
            get => _newJob;
            set
            {
                _newJob = value;
                OnPropertyChanged("NewJob");
            }
        }
        public ObservableCollection<Contractor> AvaliableContractors
        {
            get => _avaliableContractors;
            set
            {
                _avaliableContractors = value;
                OnPropertyChanged("AvaliableContractors");
            }
        }
        public string ClientID
        {
            get => _clientID;
            set
            {
                _clientID = value;
                OnPropertyChanged("ClientID");
            }
        }
        public Commander CreateJobCommand
        {
            get
            {
                if(_createJobCommand == null)
                {
                    _createJobCommand = new Commander(CreateJobMethod);
                }
                return _createJobCommand;
            }
            set => _createJobCommand = value;
        }

        public CreateJobRequestViewModel()
        {
            NewJob = new Job();
            SkillList = SQLHelper.GetAllSkills();
            AvaliableContractors = new ObservableCollection<Contractor>(ContractorSQLHelper.GetAllContractors());
        }

        public void CreateJobMethod()
        {
            NewJob.JobClient = ClientSQLHelper.GetClientFromID(int.Parse(ClientID));

            Employee loggedInEmployee = new Employee();

            foreach(Window window in Application.Current.Windows)
            {
                if(window.Title == "BIT Services Management System")
                {
                    MainWindow mainWindow = (MainWindow)window;
                    loggedInEmployee = ((MainWindow)mainWindow.DataContext).LoggedInEmployee;
                    break;
                }
            }

            if(JobSQLHelper.CreateJob(NewJob, loggedInEmployee.EmployeeID) == 1)
            {
                MessageBox.Show("Job Successfully Created", "", MessageBoxButton.OK, MessageBoxImage.Information);
                LogHelper.Log(LogTarget.EventLog, "Job Successfully Created");
            }
            else
            {
                MessageBox.Show("An Error Has Occured\nPlease check all fields and try again.", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
