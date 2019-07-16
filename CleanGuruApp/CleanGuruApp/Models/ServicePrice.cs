using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CleanGuruApp.Models
{
    public class ServicePrice
    {
        [Key]
        [Display(Name = "Service ID")]
        public int IdServicePrice { get; set; }

        //Home Cleaning
        //Maid Services
        //Window Washing
        //Commercial Cleaning
        //Move-In / Move-Out
        //Carpet Cleaning

        [Required(ErrorMessage = "Please define the service description.")]
        [Display(Name = "Service")]
        public string ServicePriceDescr { get; set; }

        [Required(ErrorMessage = "Please define the customer's service cost/hr.")]
        [Display(Name = "Price(Customer)")]
        [DisplayFormat(DataFormatString = "{0:#,##0.00#}", ApplyFormatInEditMode = true)]
        public double CtAmountHour { get; set; }

        [Required(ErrorMessage = "Please define the cleaner's service cost/hr.")]
        [Display(Name = "Cost(Cleaner)")]
        [DisplayFormat(DataFormatString = "{0:#,##0.00#}", ApplyFormatInEditMode = true)]
        public double ClAmountHour { get; set; }

        [Required(ErrorMessage = "Please identify if this is a new price to be updated.")]
        [Display(Name = "Status")]
        public char ServicePriceStatus { get; set; }


        public IEnumerable<Appointment> Appointments { get; set; }
    }
}
