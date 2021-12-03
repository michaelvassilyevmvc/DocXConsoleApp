using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocXConsoleApp.Models
{
    public class Competition
    {
        public string Name { get; set; }
        public string DateAndPlace { get; set; }
        public string Organization { get; set; }
        public string Count { get; set; }
        public string AthleteCount { get; set; }
        public string TrainerCount { get; set; }
        public string JudgesCount { get; set; }
        public string OrganizerFirm { get; set; }
        public string SendFirm { get; set; }
    }
}
