using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using BITServices.Models;
using BITServices.DAL;
using BITServices.Control;
using BITServices.UI.Windows;
using System.Windows;
using System.Collections.ObjectModel;

namespace BITServices.ViewModels
{
    class NewContractorViewModel : ViewModel
    {
        private string _defaultProfilePic = @"../../UI/Images/Portrait_Placeholder.png";

        private Contractor _newContractor;
        private string _contractorImagePath;
        private Commander _newContractorButtonCommand, _addSkillCommand;
        private string _selectedSkill;

        public string Password, PasswordCheck;

        public List<string> SkillList { get; set; }

        public Contractor NewContractor
        {
            get => _newContractor;
            set
            {
                _newContractor = value;
                OnPropertyChanged("NewContractor");
            }
        }
        public string ContractorImagePath
        {
            get => _contractorImagePath;
            set
            {
                _contractorImagePath = value;
                OnPropertyChanged("ContractorImagePath");
            }
        }
        public string SelectedSkill
        {
            get => _selectedSkill;
            set
            {
                _selectedSkill = value;
                OnPropertyChanged("SelectedSkill");
            }
        }

        public Commander NewContractorButtonCommand
        {
            get
            {
                if(_newContractorButtonCommand == null)
                {
                    _newContractorButtonCommand = new Commander(AddNewContractor);
                }
                return _newContractorButtonCommand;
            }
            set => _newContractorButtonCommand = value;
        }
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


        public NewContractorViewModel()
        {
            NewContractor = new Contractor();
            ContractorImagePath = _defaultProfilePic;
            SkillList = SQLHelper.GetAllSkills();
        }

        public void AddNewContractor()
        {
            if (ContractorImagePath != _defaultProfilePic)
            {
                NewContractor.ProfilePicData = ImageController.ImagePathToByteArray(ContractorImagePath);
            }

            NewContractor.PasswordSalt = PasswordManager.GenerateSalt();
            if(PasswordManager.CheckPasswordRules(Password, PasswordCheck))
            {
                NewContractor.PasswordHash = PasswordManager.HashPassword(Password + NewContractor.PasswordSalt);
                Password = null;
                PasswordCheck = null;
            }

            if(ContractorSQLHelper.InsertContractor(NewContractor) == 1)
            {
                MessageBox.Show("Contractor Successfully Added", "", MessageBoxButton.OK, MessageBoxImage.Information);
                LogHelper.Log(LogTarget.EventLog, "Contractor Successfully Added");
            }
            else
            {
                MessageBox.Show("An Error Has Occured\nPlease check all fields and try again.", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void AddSkillMethod()
        {
            if(SelectedSkill == null)
            {
                return;
            }
            
            if (NewContractor.SkillList != null)
            {
                foreach (string skill in NewContractor.SkillList)
                {
                    if (skill == SelectedSkill)
                    {
                        return;
                    }
                }
            }
            else
            {
                NewContractor.SkillList = new ObservableCollection<string>();
            }

            NewContractor.SkillList.Add(SelectedSkill);
        }
    }
}
