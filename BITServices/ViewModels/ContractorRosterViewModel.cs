using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BITServices.Models;
using BITServices.DAL;
using BITServices.Control;
using System.Data;
using System.Windows;

namespace BITServices.ViewModels
{
    class ContractorRosterViewModel : ViewModel
    {
        private string _rosterDay;
        private DateTime _rosterStartTime;
        private DateTime _rosterEndTime;
        private DataTable _roster;
        private int _selectedDay;
        private Commander _addDayCommand, _removeDayCommand;

        public string RosterDay
        {
            get => _rosterDay;
            set
            {
                _rosterDay = value;
                OnPropertyChanged("RosterDay");
            }
        }
        public DateTime RosterStartTime
        {
            get => _rosterStartTime;
            set
            {
                _rosterStartTime = value;
                OnPropertyChanged("RosterStartTime");
            }
        }
        public DateTime RosterEndTime
        {
            get => _rosterEndTime;
            set
            {
                _rosterEndTime = value;
                OnPropertyChanged("RosterEndTime");
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
        public int SelectedDay
        {
            get => _selectedDay;
            set
            {
                _selectedDay = value;
                OnPropertyChanged("SelectedDay");
            }
        }

        public Commander AddDayCommand
        {
            get
            {
                if(_addDayCommand == null)
                {
                    _addDayCommand = new Commander(AddDayMethod);
                }
                return _addDayCommand;
            }
            set => _addDayCommand = value;
        }
        public Commander RemoveDayCommand
        {
            get
            {
                if(_removeDayCommand == null)
                {
                    _removeDayCommand = new Commander(RemoveDayMethod);
                }
                return _removeDayCommand;
            }
            set => _removeDayCommand = value;
        }

        public ContractorRosterViewModel()
        {
            Roster = new DataTable();
            Roster.Columns.Add("Day");
            Roster.Columns.Add("Start Time");
            Roster.Columns.Add("End Time");
        }

        private void AddDayMethod()
        {
            if(RosterDay == null || RosterStartTime == null || RosterEndTime == null)
            {
                return;
            }

            foreach(DataRow dr in Roster.Rows)
            {
                if((string)dr["Day"] == RosterDay && (string)dr["Start Time"] == RosterStartTime.ToString("h:mm tt") && (string)dr["End Time"] == RosterEndTime.ToString("h:mm tt"))
                {
                    return;
                }
            }

            DataRow dataRow = Roster.NewRow();
            dataRow["Day"] = RosterDay;
            dataRow["Start Time"] = RosterStartTime.ToString("h:mm tt");
            dataRow["End Time"] = RosterEndTime.ToString("h:mm tt");
            Roster.Rows.Add(dataRow);
            OnPropertyChanged("Roster");
        }

        private void RemoveDayMethod()
        {
            if(MessageBox.Show("Are you sure you want to remove this roster day?", "Remove Roster Day", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Roster.Rows.RemoveAt(SelectedDay);
            }
        }
    }
}
