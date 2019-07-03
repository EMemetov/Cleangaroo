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
        [Display(Name = "Cleaner ID")]
        public int IdScheduleCleaner { get; set; }


        [Required(ErrorMessage = " ")]
        [Display(Name = "Day")]
        public string DayWeek { get; set; }


        [Required(ErrorMessage = "The initial time should be not blank")]
        [Display(Name = "Begin")]
        [DisplayFormat( ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm:ss}")]
        public DateTime InitialTime { get; set; }

        [Display(Name = "Finish")]
        [Required(ErrorMessage = "The finish time should be not blank")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm:ss}")]
        public DateTime FinishTime { get; set; }
        [Required(ErrorMessage = "The cleaner ID should be not blank")]
        public int IdCleaner { get; set; }
    }
}
