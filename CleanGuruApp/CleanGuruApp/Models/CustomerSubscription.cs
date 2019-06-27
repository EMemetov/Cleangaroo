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
        [Required(ErrorMessage ="The ID customer needs to be chosen")]
        public int IdCustomer{ get; set ;}
        [Required(ErrorMessage = "The subscription needs to be chosen")]
        public char Subscription{ get; set ;}
        [Required(ErrorMessage = "The periodicity should be not blank")]
        public string Periodicity{ get; set ;}
        [Required(ErrorMessage = "The end date should be not blank")]
        public DateTime FinishDate{ get; set ;}
    }
}
