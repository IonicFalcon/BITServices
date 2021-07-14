using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITServices.Models
{
    class Client : Person
    {
        private string _name;

        public int ClientID { get; set; }
        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Field is Mandatory");
                }

                if(value.Length > 80)
                {
                    throw new ArgumentException("Length Must Not Be Greater Than 80");
                }

                _name = value;
                OnPropertyChanged("Name");
            }
        }
    }
}
