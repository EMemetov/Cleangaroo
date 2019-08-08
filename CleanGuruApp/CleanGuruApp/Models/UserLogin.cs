//*********************************************************************************************************************
// Author: Theo Mitchel - Last Modified Date: August, 7th 2019.  
// Defining the fields to be used in this class
//*********************************************************************************************************************
using System.ComponentModel.DataAnnotations;

namespace CleanGuruApp.Models
{
    //class to define the fields and validate the data
    public class UserLogin
    {
        [Key]
        [Required(ErrorMessage = "Can not be empty. Please enter your user name.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Can not be empty. Please enter your password.")]
        public string Pin { get; set; }

        [Required(ErrorMessage = "Please choose one.")]
        public string Role { get; set; }
    }
}
