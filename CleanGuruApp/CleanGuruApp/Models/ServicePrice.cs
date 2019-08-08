//*********************************************************************************************************************
// Author: Theo Mitchel - Last Modified Date: August, 7th 2019.  
// Defining the fields to be used in this class
//*********************************************************************************************************************
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace CleanGuruApp.Models
{
    //class to define the fields and validate the data
    public class ServicePrice
    {
        [Key]
        [Display(Name = "Service ID")]
        public int IdServicePrice { get; set; }

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
