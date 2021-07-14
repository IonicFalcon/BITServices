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
    class ClientManagementViewModel : ViewModel
    {
        private string _defaultProfilePicName = "No Profile Pic Found";
        private Commander _dataGridSelectionCommand, _clientDetailsChangedCommand, _dataGridLostFocusCommand, _updateClientCommand, _deleteClientCommand; 

        private bool _popupBool, _detailShowBool;
        private string _clientProfilePicName;
        private ObservableCollection<Client> _clientCollection;
        private Client _selectedClient;

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
        public string ClientProfilePicName
        {
            get => _clientProfilePicName;
            set
            {
                _clientProfilePicName = value;
                OnPropertyChanged("ClientProfilePicName");
            }
        }
        public ObservableCollection<Client> ClientCollection
        {
            get => _clientCollection;
            set
            {
                _clientCollection = value;
                OnPropertyChanged("ClientCollection");
            }
        }
        public Client SelectedClient
        {
            get => _selectedClient;
            set
            {
                _selectedClient = value;
                OnPropertyChanged("SelectedClient");
            }
        }

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
        public Commander ClientDetailsChangedCommand
        {
            get
            {
                if(_clientDetailsChangedCommand == null)
                {
                    _clientDetailsChangedCommand = new Commander(ValueChangedMethod);
                }
                return _clientDetailsChangedCommand;
            }
            set => _clientDetailsChangedCommand = value;
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
        public Commander UpdateClientCommand
        {
            get
            {
                if(_updateClientCommand == null)
                {
                    _updateClientCommand = new Commander(UpdateClientMethod);
                }
                return _updateClientCommand;
            }
            set => _updateClientCommand = value;
        }
        public Commander DeleteClientCommand
        {
            get
            {
                if(_deleteClientCommand == null)
                {
                    _deleteClientCommand = new Commander(DeleteClientMethod);
                }
                return _deleteClientCommand;
            }
            set => _deleteClientCommand = value;
        }

        public ClientManagementViewModel()
        {
            RefreshDataGrid();
            _popupBool = false;
        }

        private void SetProfilePicName()
        {
            if(SelectedClient != null)
            {
                if(SelectedClient.ProfilePicData != null)
                {
                    ClientProfilePicName = "Profile Pic Found";
                }
                else
                {
                    ClientProfilePicName = _defaultProfilePicName;
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

        private void RefreshDataGrid()
        {
            SelectedClient = null;
            ClientCollection = new ObservableCollection<Client>(ClientSQLHelper.GetAllClients());
        }

        private void UpdateClientMethod()
        {
            if (ClientProfilePicName != _defaultProfilePicName && ClientProfilePicName != "Profile Pic Found")
            {
                SelectedClient.ProfilePicData = ImageController.ImagePathToByteArray(ClientProfilePicName);
            }

            if(ClientSQLHelper.UpdateClient(SelectedClient) == 1)
            {
                MessageBox.Show("Client Successfully Updated", "", MessageBoxButton.OK, MessageBoxImage.Information);
                LogHelper.Log(LogTarget.EventLog, "Client Successfully Updated");
                RefreshDataGrid();
                PopupBool = false;
                ClientProfilePicName = _defaultProfilePicName;
            }
            else
            {
                MessageBox.Show("An Error Has Occured\nPlease check all fields and try again.", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteClientMethod()
        {
            if(MessageBox.Show("Are you sure you want to delet this client?\nThis cannot be undone.", "Delete Client", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                if(ClientSQLHelper.DeleteClient(SelectedClient) == 1)
                {
                    MessageBox.Show("Client Successfully Deleted", "", MessageBoxButton.OK, MessageBoxImage.Information);
                    LogHelper.Log(LogTarget.EventLog, "Client Successfully Deleted");
                    RefreshDataGrid();
                    PopupBool = false;
                    ClientProfilePicName = _defaultProfilePicName;
                }
                else
                {
                    MessageBox.Show("An Error Has Occured\nPlease try again.", "", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
