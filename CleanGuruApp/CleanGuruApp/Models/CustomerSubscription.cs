using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CleanGuruApp.Models
{
    public class CustomerSubscription
    {
        [Key]
        public int IdSubscription{ get; set ;}
        [Range(1,365)]
        [Required(ErrorMessage = "The periodicity should be greater than 0 and less than 365 days")]
        public int Periodicity{ get; set ;}
        [Required(ErrorMessage = "The end date should be not blank")]
        public DateTime FinishDate{ get; set ;}
        [Required(ErrorMessage = "The appointment should be not blank")]
        public int IdAppointment { get; set; }
    }
}
