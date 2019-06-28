using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CleanGuruApp.Models
{
    public class AppointmentPayment
    {
        [Key]
        public int IdAppointmentPayment{ get; set ; }

        [Required(ErrorMessage ="The appointment shouldn't be blank")]
        public int IdAppointment{ get; set ; }

        [Range(0, 12)]
        public int CtHoursContracted { get; set; }
        
        [Range(0, 12)]
        public int ClHoursWorked { get; set; }
    
        public bool PaidByCustomer{ get; set ;}

        public bool PaidToCleaner { get; set; }

        [DataType(DataType.Currency)]
        public double AmountPaidByCustomer{ get; set ;}

        [DataType(DataType.Currency)]
        public double AmountPaidToCleaner { get; set; }
        
    }
}
