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
using System.Windows;

namespace BITServices.ViewModels
{
    class NewCoordinatorViewModel : ViewModel
    {
        private string _defaultProfilePic = @"../../UI/Images/Portrait_Placeholder.png";

        private Employee _newCoordinator;
        private string _coordinatorImagePath;
        private Commander _newCoordinatorButtonCommand;

        public string Password, PasswordCheck;
        public Employee NewCoordinator
        {
            get => _newCoordinator;
            set
            {
                _newCoordinator = value;
                OnPropertyChanged("NewCoordinator");
            }
        }

        public string CoordinatorImagePath
        {
            get => _coordinatorImagePath;
            set
            {
                _coordinatorImagePath = value;
                OnPropertyChanged("CoordinatorImagePath");
            }
        }

        public Commander NewCoordinatorButtonCommand
        {
            get
            {
                if(_newCoordinatorButtonCommand == null)
                {
                    _newCoordinatorButtonCommand = new Commander(AddNewCoordinator);
                }
                return _newCoordinatorButtonCommand;
            }

            set => _newCoordinatorButtonCommand = value;
        }


        public NewCoordinatorViewModel()
        {
            NewCoordinator = new Employee();
            CoordinatorImagePath = _defaultProfilePic;
        }

        /// <summary>
        /// Adds Coordinator to Database
        /// </summary>
        public void AddNewCoordinator()
        {
            if(CoordinatorImagePath != _defaultProfilePic)
            {
                NewCoordinator.ProfilePicData = ImageController.ImagePathToByteArray(CoordinatorImagePath);
            }

            NewCoordinator.EmployeeType = "Coordinator";
            NewCoordinator.PasswordSalt = PasswordManager.GenerateSalt();
            if(PasswordManager.CheckPasswordRules(Password, PasswordCheck))
            {
                NewCoordinator.PasswordHash = PasswordManager.HashPassword(Password + NewCoordinator.PasswordSalt);
                Password = null;
                PasswordCheck = null;
            }
            else
            {
                return;
            }

            if(CoordinatorSQLHelper.InsertCoordinator(NewCoordinator) == 1)
            {
                MessageBox.Show("Coordinator Successfully Added", "", MessageBoxButton.OK, MessageBoxImage.Information);
                LogHelper.Log(LogTarget.EventLog, "Coordinator Successfully Added");
            }
            else
            {
                MessageBox.Show("An Error Has Occured\nPlease check all fields and try again.", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
