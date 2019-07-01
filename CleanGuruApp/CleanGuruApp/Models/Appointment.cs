using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CleanGuruApp.Models
{
    public class Appointment
    {
        [Key]
        public int IdAppointment{ get; set ;}
        //[Required(ErrorMessage ="Please choose the service type.")]
        public int IdServicePrice{ get; set ;}
        //[Required(ErrorMessage = "The system did not inform the customer's ID.")]
        public int IdCustomer{ get; set ;}
        //[Required(ErrorMessage = "Enter a valid date")]
        public DateTime CtDateRequestService{ get; set ;}
        //[Required(ErrorMessage = "The requested hours should be between 1-8")]
        //[Range(0,8)]
        public int CtHoursRequested{ get; set ;}
        public int IdCleaner{ get; set ;}
        public DateTime? ClockIn{ get; set ;}
        public DateTime? ClockOut{ get; set ;}
        public string CleanerRate { get; set; }
        public DateTime? startTime { get; set; }
        public int isSubscription { get; set; }
    }
}
