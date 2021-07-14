using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BITServices.Control;

namespace BITServices.Models
{
    public class Employee : Person, IUser
    {
        private string _firstName;
        private string _lastName;

        public int EmployeeID { get; set; }
        public string FirstName
        {
            get => _firstName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Field is Mandatory");
                }

                if(value.Length > 40)
                {
                    throw new ArgumentException("Length Must Not Be Greater Than 40");
                }

                _firstName = value;
                OnPropertyChanged("FirstName");
            }
        }
        public string LastName
        {
            get => _lastName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Field is Mandatory");
                }

                if (value.Length > 40)
                {
                    throw new ArgumentException("Length Must Not Be Greater Than 40");
                }

                _lastName = value;
                OnPropertyChanged("LastName");
            }
        }
        public string EmployeeType { get; set; }
        public bool Login(string enteredPassword)
        {
            string unknownHash = enteredPassword + PasswordSalt;            //Append salt for user from username

            return (PasswordManager.VerifyPassword(unknownHash, PasswordHash));  //Check against known hash for password
        }

    }
}
