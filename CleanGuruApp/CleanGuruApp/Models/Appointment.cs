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
        [Required(ErrorMessage ="The service price needs to be chosen")]
        public int IdServicePrice{ get; set ;}
        [Required(ErrorMessage = "The ID customer needs to be chosen")]
        public int IdCustomer{ get; set ;}
        [Required(ErrorMessage = "The date of requested service should be not blank")]
        public DateTime CtDateRequestService{ get; set ;}
        [Required(ErrorMessage = "The requested hours should be between 1-12")]
        [Range(0,12)]
        public int CtHoursRequested{ get; set ;}
        public int IdCleaner{ get; set ;}
        public DateTime ClockIn{ get; set ;}
        public DateTime ClockOut{ get; set ;}
        public string CleanerRate{ get; set ;}
    }
}
