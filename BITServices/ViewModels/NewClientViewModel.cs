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
    class NewClientViewModel : ViewModel
    {
        private string _defaultProfilePic = @"../../UI/Images/Portrait_Placeholder.png";

        private Client _newClient;
        private string _clientImagePath;
        private Commander _newClientButtonCommand;

        public string Password, PasswordCheck;
        public Client NewClient
        {
            get => _newClient;
            set
            {
                _newClient = value;
                OnPropertyChanged("NewClient");
            }
        }
        public string ClientImagePath
        {
            get => _clientImagePath;
            set
            {
                _clientImagePath = value;
                OnPropertyChanged("ClientImagePath");
            }
        }
        public Commander NewClientButtonCommand
        {
            get
            {
                if(_newClientButtonCommand == null)
                {
                    _newClientButtonCommand = new Commander(AddNewClient);
                }
                return _newClientButtonCommand;
            }
            set => _newClientButtonCommand = value;
        }

        public NewClientViewModel()
        {
            NewClient = new Client();
            ClientImagePath = _defaultProfilePic;
        }

        public void AddNewClient()
        {
            if(ClientImagePath != _defaultProfilePic)
            {
                NewClient.ProfilePicData = ImageController.ImagePathToByteArray(ClientImagePath);
            }

            NewClient.PasswordSalt = PasswordManager.GenerateSalt();
            if(PasswordManager.CheckPasswordRules(Password, PasswordCheck))
            {
                NewClient.PasswordHash = PasswordManager.HashPassword(Password + NewClient.PasswordSalt);
                Password = null;
                PasswordCheck = null;
            }
            else
            {
                return;
            }

            if(ClientSQLHelper.InsertClient(NewClient) == 1)
            {
                MessageBox.Show("Client Successfully Added", "", MessageBoxButton.OK, MessageBoxImage.Information);
                LogHelper.Log(LogTarget.EventLog, "Client Successfully Added");
            }
            else
            {
                MessageBox.Show("An Error Has Occured\nPlease check all fields and try again.", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
