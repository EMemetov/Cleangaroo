using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CleanGuruApp.Models
{
    public class Customers
    {
        [Key]
        public int IdCustomer { get; set; }
        [Required(ErrorMessage ="The customer first name should be not blank")]
        public string FCustomerName { get; set; }
        public string MCustomerName { get; set; }
        [Required(ErrorMessage = "The customer last name should be not blank")]
        public string LCustomerName { get; set; }
        public string CtPhone1 { get; set; }
        public string CtPhone2 { get; set; }
        [Required(ErrorMessage = "The user name should be not blank")]
        public string UserName { get; set; }
    }
}
