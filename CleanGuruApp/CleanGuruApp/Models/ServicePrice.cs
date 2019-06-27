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
        [Required(ErrorMessage ="The customer amount should be not blank")]
        [DataType(DataType.Currency)]
        public double CtAmountHour { get; set; }
        [Required(ErrorMessage = "The cleaner amount should be not blank")]
        [DataType(DataType.Currency)]
        public double ClAmountHour { get; set; }
        [Required(ErrorMessage = "The status needs to be chosen")]
        public bool ServicePriceStatus { get; set; }
    }
}
