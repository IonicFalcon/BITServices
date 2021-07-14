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
    class ContractorManagementViewModel : ViewModel
    {
        private string _defaultProfilePicName = "No Profile Pic Found";
        private Commander _dataGridSelectionCommand, _contractorDetailsChangedCommand, _updateContractorCommand, _dataGridLostFocusCommand, _deleteContractorCommand;

        private bool _popupBool, _detailShowBool;
        private string _contractorProfilePicName;
        private ObservableCollection<Contractor> _contractorCollection;
        private Contractor _selectedContractor;

        public bool PopupBool
        {
            get => _popupBool;
            set
            {
                _popupBool = value;
                OnPropertyChanged("PopupBool");
            }
        }
        public bool DetailShowBool
        {
            get => _detailShowBool;
            set
            {
                _detailShowBool = value;
                OnPropertyChanged("DetailShowBool");
            }
        }
        public string ContractorProfilePicName
        {
            get => _contractorProfilePicName;
            set
            {
                _contractorProfilePicName = value;
                OnPropertyChanged("ContractorProfilePicName");
            }
        }
        public ObservableCollection<Contractor> ContractorCollection
        {
            get => _contractorCollection;
            set
            {
                _contractorCollection = value;
                OnPropertyChanged("ContractorCollection");
            }
        }
        public Contractor SelectedContractor
        {
            get => _selectedContractor;
            set
            {
                _selectedContractor = value;
                OnPropertyChanged("SelectedContractor");
            }
        }

        //Commander Definitions
        public Commander DataGridSelectionCommand
        {
            get
            {
                if(_dataGridSelectionCommand == null)
                {
                    _dataGridSelectionCommand = new Commander(SetProfilePicName);
                }
                return _dataGridSelectionCommand;
            }
            set => _dataGridSelectionCommand = value;
        }
        public Commander ContractorDetailsChangedCommand
        {
            get
            {
                if(_contractorDetailsChangedCommand == null)
                {
                    _contractorDetailsChangedCommand = new Commander(ValueChangedMethod);
                }
                return _contractorDetailsChangedCommand;
            }
            set => _contractorDetailsChangedCommand = value;
        }
        public Commander UpdateContractorCommand
        {
            get
            {
                if(_updateContractorCommand == null)
                {
                    _updateContractorCommand = new Commander(UpdateContractorMethod);
                }
                return _updateContractorCommand;
            }
            set => _updateContractorCommand = value;
        }
        public Commander DataGridLostFocusCommand
        {
            get
            {
                if(_dataGridLostFocusCommand == null)
                {
                    _dataGridLostFocusCommand = new Commander(RefreshDataGrid);
                }
                return _dataGridLostFocusCommand;
            }
            set => _dataGridLostFocusCommand = value;
        }
        public Commander DeleteContractorCommand
        {
            get
            {
                if(_deleteContractorCommand == null)
                {
                    _deleteContractorCommand = new Commander(DeleteContractorMethod);
                }
                return _deleteContractorCommand;
            }
            set => _deleteContractorCommand = value;
        }


        public ContractorManagementViewModel()
        {
            RefreshDataGrid();
            _popupBool = false;
        }

        private void SetProfilePicName()
        {
            if(SelectedContractor != null)
            {
                if(SelectedContractor.ProfilePicData != null)
                {
                    ContractorProfilePicName = "Profile Pic Found";
                }
                else
                {
                    ContractorProfilePicName = _defaultProfilePicName;
                }
            }
            DetailShowBool = true;
        }

        private void ValueChangedMethod()
        {
            if (!PopupBool)
            {
                PopupBool = true;
            }
        }

        private void UpdateContractorMethod()
        {
            if(ContractorProfilePicName != _defaultProfilePicName && ContractorProfilePicName != "Profile Pic Found")
            {
                SelectedContractor.ProfilePicData = ImageController.ImagePathToByteArray(ContractorProfilePicName);
            }

            if (ContractorSQLHelper.UpdateContractor(SelectedContractor) == 1)
            {
                MessageBox.Show("Contractor Successfully Updated", "", MessageBoxButton.OK, MessageBoxImage.Information);
                LogHelper.Log(LogTarget.EventLog, "Contractor Successfully Updated");
                RefreshDataGrid();
                PopupBool = false;
                ContractorProfilePicName = _defaultProfilePicName;
            }
            else
            {
                MessageBox.Show("An Error Has Occured\nPlease check all fields and try again.", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteContractorMethod()
        {
            if(MessageBox.Show("Are you sure you want to delete this contractor?\nThis cannot be undone.", "Delete Contractor", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                if(ContractorSQLHelper.DeleteContractor(SelectedContractor) == 1)
                {
                    MessageBox.Show("Contractor Successfully Deleted", "", MessageBoxButton.OK, MessageBoxImage.Information);
                    LogHelper.Log(LogTarget.EventLog, "Contractor Successfully Deleted");
                    RefreshDataGrid();
                    PopupBool = false;
                    ContractorProfilePicName = _defaultProfilePicName;
                }
                else
                {
                    MessageBox.Show("An Error Has Occured\nPlease try again.", "", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void RefreshDataGrid()
        {
            SelectedContractor = null;
            ContractorCollection = new ObservableCollection<Contractor>(ContractorSQLHelper.GetAllContractors());
        }


        //Contractor Skills
        private Commander _addSkillCommand, _removeSkillCommand;
        private List<string> _skillList;

        public List<string> SkillList
        {
            get
            {
                if(_skillList == null)
                {
                    _skillList = SQLHelper.GetAllSkills();
                }
                return _skillList;
            }
            set => _skillList = value;
        }
        public string SelectedSkill { get; set; }
        public string SelectedSkillList { get; set; }

        public Commander AddSkillCommand
        {
            get
            {
                if(_addSkillCommand == null)
                {
                    _addSkillCommand = new Commander(AddSkillMethod);
                }
                return _addSkillCommand;
            }
            set => _addSkillCommand = value;
        }
        public Commander RemoveSkillCommand
        {
            get
            {
                if(_removeSkillCommand == null)
                {
                    _removeSkillCommand = new Commander(RemoveSkillMethod);
                }
                return _removeSkillCommand;
            }
            set => _removeSkillCommand = value;
        }

        private void AddSkillMethod()
        {
            if (SelectedSkill == null)
            {
                return;
            }

            if(SelectedContractor.SkillList != null)
            {
                foreach(string skill in SelectedContractor.SkillList)
                {
                    if(skill == SelectedSkill)
                    {
                        return;
                    }
                }
            }
            else
            {
                SelectedContractor.SkillList = new ObservableCollection<string>();
            }

            SelectedContractor.SkillList.Add(SelectedSkill);
        }

        private void RemoveSkillMethod()
        {
            if(SelectedSkillList == null)
            {
                return;
            }

            if(SelectedContractor.SkillList != null)
            {
                for(int i = 0; i < SelectedContractor.SkillList.Count; i++)
                {
                    if(SelectedContractor.SkillList[i] == SelectedSkillList)
                    {
                        SelectedContractor.SkillList.RemoveAt(i);
                        break;
                    }
                }
            }
        }


        //Contractor Roster
        private Commander _addRosterDayCommand, _removeRosterDayCommand;
        private int _selectedDay;

        public string RosterDay { get; set; }
        public DateTime RosterStartTime { get; set; }
        public DateTime RosterEndTime { get; set; }
        public int SelectedDay
        {
            get => _selectedDay;
            set
            {
                _selectedDay = value;
                OnPropertyChanged("SelectedDay");
            }
        }

        public Commander AddRosterDayCommand
        {
            get
            {
                if(_addRosterDayCommand == null)
                {
                    _addRosterDayCommand = new Commander(AddRosterDayMethod);
                }
                return _addRosterDayCommand;
            }
            set => _addRosterDayCommand = value;
        }
        public Commander RemoveRosterDayCommand
        {
            get
            {
                if(_removeRosterDayCommand == null)
                {
                    _removeRosterDayCommand = new Commander(RemoveRosterDayMethod);
                }
                return _removeRosterDayCommand;
            }
            set => _removeRosterDayCommand = value;
        }

        private void AddRosterDayMethod()
        {
            if(RosterDay == null || RosterStartTime == null || RosterEndTime == null)
            {
                return;
            }

            foreach(DataRow dr in SelectedContractor.Roster.Rows)
            {
                if((string)dr["DayOfWeek"] == RosterDay && (string)dr["StartTime"] == RosterStartTime.ToString("H:mm") && (string)dr["EndTime"] == RosterEndTime.ToString("H:mm")){
                    return;
                }
            }

            DataRow dataRow = SelectedContractor.Roster.NewRow();
            dataRow["DayOfWeek"] = RosterDay;
            dataRow["StartTime"] = RosterStartTime.ToString("H:mm");
            dataRow["EndTime"] = RosterEndTime.ToString("H:mm");
            SelectedContractor.Roster.Rows.Add(dataRow);
        }

        private void RemoveRosterDayMethod()
        {
            if(MessageBox.Show("Are you sure you want to remove this roster day?", "Remove Roster Day", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                SelectedContractor.Roster.Rows.RemoveAt(SelectedDay);
            }
        }
    }
}
