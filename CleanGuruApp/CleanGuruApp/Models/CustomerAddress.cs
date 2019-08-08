//*********************************************************************************************************************
// Author: Fernando Martin - Last Modified Date: August, 7th 2019.  
// Defining the fields to be used in this class
//*********************************************************************************************************************
using System.ComponentModel.DataAnnotations;


namespace CleanGuruApp.Models
{
    //class to define the fields and validate the data
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
