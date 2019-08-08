//*********************************************************************************************************************
// Author: Andrea Cavalheiro - Last Modified Date: August, 7th 2019.  
// Defining the fields to be used in this class
//*********************************************************************************************************************
using System.ComponentModel.DataAnnotations;

namespace CleanGuruApp.Models
{
    public class AppointmentPayment
    {
        [Key]
        public int IdAppointmentPayment{ get; set ; }

        [Required(ErrorMessage = "The system did not inform the appointment's ID.")]
        public int IdAppointment{ get; set ; }

        [Required(ErrorMessage = "The system inform a wrong amout of contracted hrs.")]
        [Range(0, 8)]
        public int CtHoursContracted { get; set; }

        [Required(ErrorMessage = "The system inform a wrong amout of worked hrs.")]
        [Range(0, 8)]
        public int ClHoursWorked { get; set; }
    
        [DataType(DataType.Currency)]
        public double AmountPaidByCustomer{ get; set ;}

        [DataType(DataType.Currency)]
        public double AmountPaidToCleaner { get; set; }

        //functionality not implemented for this fields
        public bool PaidByCustomer { get; set; }
        public bool PaidToCleaner { get; set; }
    }
}
