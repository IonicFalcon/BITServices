using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace BITServices.Models
{
    public abstract class Person : INotifyPropertyChanged
    {
        private string _street;
        private string _suburb;
        private string _state;
        private string _postCode;
        private string _phoneNumber;
        private string _mobileNumber;
        private string _email;
        private byte[] _profilePicData;
        private string _userName;
        private string _passwordHash;
        private string _passwordSalt;

        public string Street
        {
            get => _street;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Field is Mandatory");
                }

                if(value.Length > 50)
                {
                    throw new ArgumentException("Length Must Not Be Greater Than 50");
                }

                _street = value;
                OnPropertyChanged("Street");
            }
        }
        public string Suburb
        {
            get => _suburb;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Field is Mandatory");
                }

                if(value.Length > 30)
                {
                    throw new ArgumentException("Length Must Not Be Greater Than 50");
                }

                _suburb = value;
                OnPropertyChanged("Suburb");
            }
        }
        public string State
        {
            get => _state;
            set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Field is Mandatory");
                }
                _state = value;
                OnPropertyChanged("State");
            }
        }
        public string PostCode
        {
            get => _postCode;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Field is Mandatory");
                }

                if(value.Length != 4)
                {
                    throw new ArgumentException("Invalid Post Code Length");
                }

                _postCode = value;
                OnPropertyChanged("PostCode");
            }
        }
        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                if(!Regex.IsMatch(value, "\\d{8}")) 
                {
                    if (!Regex.IsMatch(value, "\\d{10}"))
                    {
                        throw new ArgumentException("Invalid Australian Phone Number");
                    }
                }

                _phoneNumber = value;
                OnPropertyChanged("PhoneNumber");
            }
        }
        public string MobileNumber
        {
            get => _mobileNumber;
            set
            {
                if(!Regex.IsMatch(value, "\\d{10}"))
                {
                    throw new ArgumentException("Invalid Australian Mobile Number");
                }

                _mobileNumber = value;
                OnPropertyChanged("MobileNumber");
            }
        }
        public string Email
        {
            get => _email;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Field is Mandatory");
                }

                if(!Regex.IsMatch(value, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z"))
                {
                    throw new ArgumentException("Invalid Email");
                }
                _email = value;
                OnPropertyChanged("Email");
            }
        }
        public byte[] ProfilePicData
        {
            get => _profilePicData;
            set
            {
                _profilePicData = value;
                OnPropertyChanged("ProfilePicData");
            }
        }
        public string Username
        {
            get => _userName;
            set
            {
                _userName = value;
                OnPropertyChanged("Username");
            }
        }
        public string PasswordHash
        {
            get => _passwordHash;
            set
            {
                _passwordHash = value;
                OnPropertyChanged("PasswordHash");
            }
        }
        public string PasswordSalt
        {
            get => _passwordSalt;
            set
            {
                _passwordSalt = value;
                OnPropertyChanged("PasswordSalt");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
}
