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
        public string UserName { get; set; }
        [Required(ErrorMessage = "Can not be empty. Please enter your password.")]
        public string Pin { get; set; }
        [Required(ErrorMessage = "Please choose one.")]
        public string Role { get; set; }
    }
}
