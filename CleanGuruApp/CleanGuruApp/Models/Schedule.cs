using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanGuruApp.Models
{
    public class Schedule
    {
        public int IdSchedule{ get; set ;}
        public int IdServicePrice{ get; set ;}
        public int IdCustomer{ get; set ;}
        public DateTime CtDateRequestService{ get; set ;}
        public string CtAddress{ get; set ;}
        public int CtHoursRequested{ get; set ;}
        public int IdCleaner{ get; set ;}
        public DateTime ClockIn{ get; set ;}
        public DateTime ClockOut{ get; set ;}
        public int IdCustAddress{ get; set ;}
    }
}
