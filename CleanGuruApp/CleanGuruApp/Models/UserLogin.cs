using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CleanGuruApp.Models
{
    public class UserLogin
    {
        [Key]
        [Required(ErrorMessage = "Can not be empty. Please enter your user name.")]
        //[Range(3, 40, ErrorMessage = "Can not be empty. Please enter your user name.")]
        public string UserName { get; set; }
        //[Range(3, 8, ErrorMessage = "Please enter a password between 3 and 8 digits.")]
        public string Pin { get; set; }
        [Required(ErrorMessage = "Please choose one of the choices!")]
        public string Role { get; set; }
    }
}
