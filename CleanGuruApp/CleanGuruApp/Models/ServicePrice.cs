using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CleanGuruApp.Models
{
    public class ServicePrice
    {
        [Key]
        public int IdServicePrice { get; set; }

        //Home Cleaning
        //Maid Services
        //Window Washing
        //Commercial Cleaning
        //Move-In / Move-Out
        //Carpet Cleaning
        [Required(ErrorMessage = "Please define the service description.")]
      public string ServicePriceDescr { get; set; }

        [Required(ErrorMessage = "Please define the customer's service cost/hr.")]
        public float CtAmountHour { get; set; }

        [Required(ErrorMessage = "Please define the cleaner's service cost/hr.")]
        public float ClAmountHour { get; set; }

        [Required(ErrorMessage = "Please identify if this is a new price to be updated.")]
        public char ServicePriceStatus { get; set; }
    }
}
