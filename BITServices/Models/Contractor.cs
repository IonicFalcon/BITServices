using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITServices.Models
{
    class Contractor : Person
    {
        private string _firstName;
        private string _lastName;
        private ObservableCollection<string> _skillList;
        private DataTable _roster;
        private int _rating;

        public int ContractorID { get; set; }
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

                if(value.Length > 40)
                {
                    throw new ArgumentException("Length Must Not Be Greater Than 40");
                }

                _lastName = value;
                OnPropertyChanged("LastName");
            }
        }
        public ObservableCollection<String> SkillList
        {
            get => _skillList;
            set
            {
                _skillList = value;
                OnPropertyChanged("SkillList");
            }
        }
        public DataTable Roster
        {
            get => _roster;
            set
            {
                _roster = value;
                OnPropertyChanged("Roster");
            }
        }
        public int Rating
        {
            get => _rating;
            set
            {
                if(value < 0 || value > 100)
                {
                    throw new ArgumentException("Rating Value Out of Range");
                }

                _rating = value;
                OnPropertyChanged("Rating");
            }
        }

    }
}
