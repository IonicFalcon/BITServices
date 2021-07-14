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
    class EditJobRequestViewModel : ViewModel
    {
        private Job _editJob;
        private ObservableCollection<Contractor> _avaliableContractors;
        private int _clientID;
        private Commander _editJobCommand;

        public List<string> SkillList { get; set;}
        public Job EditJob
        {
            get => _editJob;
            set
            {
                _editJob = value;
                OnPropertyChanged("EditJob");
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
        public int ClientID
        {
            get => _clientID;
            set
            {
                _clientID = value;
                OnPropertyChanged("ClientID");
            }
        }
        public Commander EditJobCommand
        {
            get
            {
                if(_editJobCommand == null)
                {
                    _editJobCommand = new Commander(EditJobMethod);
                }
                return _editJobCommand;
            }
            set => _editJobCommand = value;
        }

        public EditJobRequestViewModel()
        {
            EditJob = new Job();
            SkillList = SQLHelper.GetAllSkills();
            AvaliableContractors = new ObservableCollection<Contractor>(ContractorSQLHelper.GetAllContractors());
        }

        public void EditJobMethod()
        {
            EditJob.JobClient = ClientSQLHelper.GetClientFromID(ClientID);

            if(JobSQLHelper.EditJob(EditJob) == 1)
            {
                MessageBox.Show("Job Successfully Edited", "", MessageBoxButton.OK, MessageBoxImage.Information);
                LogHelper.Log(LogTarget.EventLog, "Job Successfully Updated");
            }
            else
            {
                MessageBox.Show("An Error Has Occured\nPlease check all fields and try again.", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
