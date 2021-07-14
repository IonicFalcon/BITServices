using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITServices.Models
{
    class Job
    {
        public DateTime Date { get; set; }
        public string StartTime { get; set; }
        public Client JobClient { get; set; }
        public string EndDateTime { get; set; }
        public Contractor AssignedContractor { get; set; }
        public string Street { get; set; }
        public string Suburb { get; set; }
        public string State { get; set; }
        public string PostCode { get; set; }
        public int DistanceTravelled { get; set; }
        public string Urgency { get; set; }
        public Employee AssignedEmployee { get; set; }
        public string SkillType { get; set; }
        public string JobDetails { get; set; }
        public string JobStatus { get; set; }
    }
}
