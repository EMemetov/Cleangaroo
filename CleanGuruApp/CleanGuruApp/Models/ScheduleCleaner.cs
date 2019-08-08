//*********************************************************************************************************************
// Author: Theo Mitchel - Last Modified Date: August, 7th 2019.  
// Defining the fields to be used in this class
//*********************************************************************************************************************
using System;
using System.ComponentModel.DataAnnotations;


namespace CleanGuruApp.Models
{
    //class to define the fields and validate the data
    public class ScheduleCleaner
    {
        [Key]
     
        public int IdScheduleCleaner { get; set; }

        [Required(ErrorMessage = " ")]
        [Display(Name = "Days")]
        public string DayWeek { get; set; }

        [Required(ErrorMessage = "The initial time should be not blank")]
        [Display(Name = "Begin")]
        [DisplayFormat(ApplyFormatInEditMode = true)]
        public DateTime InitialTime { get; set; }

        [Required(ErrorMessage = "The finish time should be not blank")]
        [Display(Name = "Finish")]
        [DisplayFormat(ApplyFormatInEditMode = true)]
        public DateTime FinishTime { get; set; }

        [Required(ErrorMessage = "The cleaner ID should be not blank")]
        [Display(Name = "Cleaner ID")]
        public int IdCleaner { get; set; }
    }
}
