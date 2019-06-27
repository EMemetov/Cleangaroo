using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CleanGuruApp.Models
{
    public class CustomerAddress
    {
        [Key]
        public int IdCustAddress { get; set; }
        [Required(ErrorMessage = "The customer should be not blank")]
        public int idCustomer { get; set; }
        [Required(ErrorMessage = "The customer address should be not blank")]
        public string Address { get; set; }
        public string AddressUnit { get; set; }
        [Required(ErrorMessage = "The postal code should be not blank")]
        public string PostalCode { get; set; }
        [Required(ErrorMessage = "The customer city should be not blank")]
        public string City { get; set; }
        [Required(ErrorMessage = "The customer province should be not blank")]
        public string Province { get; set; }
    }
}
