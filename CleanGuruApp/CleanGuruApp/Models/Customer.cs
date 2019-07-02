using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CleanGuruApp.Models
{
    public class Customer
    {
        [Key]
        public int IdCustomer { get; set; }
        [Required(ErrorMessage = "Please enter a valid first name.")]
        public string FCustomerName { get; set; }
        public string MCustomerName { get; set; }
        [Required(ErrorMessage = "Please enter a valid family name.")]
        public string LCustomerName { get; set; }
        [Required(ErrorMessage = "Please enter a valid phone.")]
        public string CtPhone1 { get; set; }
        public string CtPhone2 { get; set; }
        [Required(ErrorMessage = "Can not be empty. Please enter your user name.")]
        public string UserName { get; set; }
    }
}
