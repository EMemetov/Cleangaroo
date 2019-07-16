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
        public int idCustAddress { get; set; }
        [Required(ErrorMessage = "The system did not inform the customer's ID.")]
        public int IdCustomer { get; set; }
        [Required(ErrorMessage = "Please enter a valid address.")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please enter a valid Unit.")]
        public string AddressUnit { get; set; }
        [Required(ErrorMessage = "Please enter a valid postal code.")]
        [StringLength(6)]
        public string PostalCode { get; set; }
        [Required(ErrorMessage = "Please enter a valid city.")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please enter a valid province.")]
        public string Province { get; set; }

        public Customer Customer { get; set; }
    }
}
