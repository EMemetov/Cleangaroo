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

        [Required(ErrorMessage = "Please define the service description.")]
        //Home Cleaning
        //Maid Serivces
        //Window Washing
        //Commercial Cleaning
        //Move-In/Move-Out
        //Carpet Cleaning
        public double ServicePriceDescr { get; set; }

        [Required(ErrorMessage = "Please define the customer's service cost/hr.")]
        public double CtAmountHour { get; set; }

        [Required(ErrorMessage = "Please define the cleaner's service cost/hr.")]
        public double ClAmountHour { get; set; }

        [Required(ErrorMessage = "Please identify if this is a new price to be updated.")]
        public char ServicePriceStatus { get; set; }
    }
}
