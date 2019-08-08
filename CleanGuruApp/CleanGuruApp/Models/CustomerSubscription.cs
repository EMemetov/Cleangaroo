//*********************************************************************************************************************
// Author: Fernando Martin - Last Modified Date: August, 7th 2019.  
// Defining the fields to be used in this class
//*********************************************************************************************************************
using System;
using System.ComponentModel.DataAnnotations;

namespace CleanGuruApp.Models
{
    //class to define the fields and validate the data
    public class CustomerSubscription
    {
        [Key]
        public int IdSubscription{ get; set ;}

        [Required(ErrorMessage = "The periodicity should be not blank")]
        [Range(1,365, ErrorMessage = "The periodicity should be greater than 0 and less than 365 days")]
        public int Periodicity{ get; set ;}
    
        [Required(ErrorMessage = "The end date should be not blank")]
        public DateTime FinishDate{ get; set ;}

        [Required(ErrorMessage = "The appointment should be not blank")]
        public int IdAppointment { get; set; }
    }
}
