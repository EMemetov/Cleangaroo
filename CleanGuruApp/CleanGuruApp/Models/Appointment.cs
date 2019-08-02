using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CleanGuruApp.Models
{
    public class Appointment
    {
        [Key]
        [Display(Name ="Appointment ID")]
        public int IdAppointment{ get; set ;}
        [Required(ErrorMessage ="Please choose the service type.")]
        public int IdServicePrice{ get; set ;}
        [Required(ErrorMessage = "The system did not inform the customer's ID.")]

        [Display(Name = "Customert ID")]
        public int IdCustomer{ get; set ;}
        [Display(Name = "Date Requested")]
        [Required(ErrorMessage = "Enter a valid date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime CtDateRequestService{ get; set ;}
        [Display(Name = "Hours Requested")]
        [Required(ErrorMessage = "The requested hours should be between 1-8")]
        [Range(0, 8)]
        public int? CtHoursRequested{ get; set ;}
        public int IdCleaner{ get; set ;}
        public DateTime? ClockIn{ get; set ;}
        public DateTime? ClockOut{ get; set ;}
        public string CleanerRate{ get; set ;}
        [DisplayFormat(DataFormatString = "{0:h:mm tt}")]
        [Required(ErrorMessage = "Enter a valid Start Time")]
        public DateTime? StartTime { get; set; }           //Should not allow NULL - Adjust later
        public bool IsSubscription { get; set; }
        [NotMapped]
        public string IsSubscriptionCheck;
        [NotMapped]
        public string isSubscriptionCheck
        {
            get
            {
                return IsSubscriptionCheck;
            }
            set
            {
                if (value == "false")
                {
                    IsSubscription = false;
                }
                else
                    IsSubscription = true;
            }
        }
        public CustomerSubscription CustSub { get; set; }
        [NotMapped]
        [DisplayFormat(DataFormatString = "{N2}", ApplyFormatInEditMode = true)]
        public Double? Total;
        [NotMapped]
        [DisplayFormat(DataFormatString = "{N2}", ApplyFormatInEditMode = true)]
        public int TotalHoursWorked
        {
            get
            {
                if (ClockIn==null || ClockOut ==null)
                {
                    return 0;
                }
                else
                {
                    TimeSpan hoursDif = Convert.ToDateTime(ClockOut) - Convert.ToDateTime(ClockIn);
                    int totalDif = hoursDif.Hours;
                    return totalDif;
                }
            }
        }

        //[Required]
        public Customer Customer { get; set; }

        public Cleaner Cleaner { get; set; }

        public ServicePrice ServicePrice { get; set; }

    }
}
