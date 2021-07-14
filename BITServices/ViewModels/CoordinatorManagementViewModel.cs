using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BITServices.Models;
using BITServices.Control;
using BITServices.DAL;
using System.Windows;
using System.IO;

namespace BITServices.ViewModels
{
    class CoordinatorManagementViewModel : ViewModel
    {
        private string _defaultProfilePicName = "No Profile Pic Found";
        private Commander _dataGridSelectionCommand, _coordinatorDetailsValueChangedCommand, _updateCoordinatorCommand, _dataGridLostFocusCommand, _deleteCoordinatorCommand;

        private bool _popupBool, _detailShowBool;
        private string _coordinatorProfilePicName;
        private ObservableCollection<Employee> _coordinatorCollection;
        private Employee _selectedCoordinator;

        public ObservableCollection<Employee> CoordinatorCollection
        {
            get => _coordinatorCollection;
            set
            {
                _coordinatorCollection = value;
                OnPropertyChanged("CoordinatorCollection");
            }
        }
        public Employee SelectedCoordinator
        {
            get => _selectedCoordinator;
            set
            {
                _selectedCoordinator = value;
                OnPropertyChanged("SelectedCoordinator");
            }
        }
        public string CoordinatorProfilePicName
        {
            get => _coordinatorProfilePicName;
            set
            {
                _coordinatorProfilePicName = value;
                OnPropertyChanged("CoordinatorProfilePicName");
            }
        }
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

        public Commander DataGridSelectionCommand
        {
            get
            {
                if (_dataGridSelectionCommand == null)
                {
                    _dataGridSelectionCommand = new Commander(SetProfilePicName);
                }
                return _dataGridSelectionCommand;
            }

            set => _dataGridSelectionCommand = value;
        }
        public Commander CoordinatorDetailsValueChangedCommand
        {
            get
            {
                if(_coordinatorDetailsValueChangedCommand == null)
                {
                    _coordinatorDetailsValueChangedCommand = new Commander(ValueChangedMethod);
                }
                return _coordinatorDetailsValueChangedCommand;
            }

            set => _coordinatorDetailsValueChangedCommand = value;
        }
        public Commander UpdateCoordinatorCommand
        {
            get
            {
                if(_updateCoordinatorCommand == null)
                {
                    _updateCoordinatorCommand = new Commander(UpdateCoordinatorMethod);
                }
                return _updateCoordinatorCommand;
            }
            set => _updateCoordinatorCommand = value;
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
        public Commander DeleteCoordinatorCommand
        {
            get
            {
                if(_deleteCoordinatorCommand == null)
                {
                    _deleteCoordinatorCommand = new Commander(DeleteCoordinatorMethod);
                }
                return _deleteCoordinatorCommand;
            }
            set => _deleteCoordinatorCommand = value;
        }

        public CoordinatorManagementViewModel()
        {
            RefreshDataGrid();
            _popupBool = false;
        }

        private void SetProfilePicName()
        {
            if (SelectedCoordinator != null)
            {

                if (SelectedCoordinator.ProfilePicData != null)
                {
                    CoordinatorProfilePicName = "Profile Pic Found";
                }
                else
                {
                    CoordinatorProfilePicName = _defaultProfilePicName;
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

        private void UpdateCoordinatorMethod()
        {
            if(CoordinatorProfilePicName != _defaultProfilePicName && CoordinatorProfilePicName != "Profile Pic Found")
            {
                SelectedCoordinator.ProfilePicData = ImageController.ImagePathToByteArray(CoordinatorProfilePicName);
            }
            
            if(CoordinatorSQLHelper.UpdateCoordinator(SelectedCoordinator) == 1)
            {
                MessageBox.Show("Coordinator Successfully Updated", "", MessageBoxButton.OK, MessageBoxImage.Information);
                LogHelper.Log(LogTarget.EventLog, "Coordinator Successfully Updated");
                RefreshDataGrid();
                PopupBool = false;
                CoordinatorProfilePicName = _defaultProfilePicName;
            }
            else
            {
                MessageBox.Show("An Error Has Occured\nPlease check all fields and try again.", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteCoordinatorMethod()
        {
            if(MessageBox.Show("Are you sure you want to delete this coordinator?\nThis cannot be undone.","Delete Coordinator", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                if(CoordinatorSQLHelper.DeleteCoordinator(SelectedCoordinator) == 1)
                {
                    MessageBox.Show("Coordinator Successfully Deleted", "", MessageBoxButton.OK, MessageBoxImage.Information);
                    LogHelper.Log(LogTarget.EventLog, "Coordinator Successfully Deleted");
                    RefreshDataGrid();
                    PopupBool = false;
                    CoordinatorProfilePicName = _defaultProfilePicName;
                }
                else
                {
                    MessageBox.Show("An Error Has Occured\nPlease try again.", "", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void RefreshDataGrid()
        {
            SelectedCoordinator = null;
            CoordinatorCollection = new ObservableCollection<Employee>(CoordinatorSQLHelper.GetAllCoordinators());
        }

    }
}
