using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CleanGuruApp.Models
{
    public class ScheduleCleaner
    {
        [Key]
     
        public int IdScheduleCleaner { get; set; }

        [Required(ErrorMessage = " ")]
        [Display(Name = "Days")]
        public string DayWeek { get; set; }
        [Required(ErrorMessage = "The initial time should be not blank")]
      //  [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm:ss}")]
        [Display(Name = "Begin")]
        [DisplayFormat(ApplyFormatInEditMode = true)]
        public DateTime InitialTime { get; set; }
        [Required(ErrorMessage = "The finish time should be not blank")]
      //  [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm:ss}")]
        [Display(Name = "Finish")]
        [DisplayFormat(ApplyFormatInEditMode = true)]
        public DateTime FinishTime { get; set; }
        [Required(ErrorMessage = "The cleaner ID should be not blank")]
        [Display(Name = "Cleaner ID")]
        public int IdCleaner { get; set; }
    }
}
