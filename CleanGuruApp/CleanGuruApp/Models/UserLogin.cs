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
        public string UserName{ get; set; }
        [Required(ErrorMessage = "The pin should be not blank")]
        [StringLength(8)]
        public string Pin{ get; set; }
        [Required(ErrorMessage = "The role should be not blank")]
        public string Role{ get; set; }
    }
}
