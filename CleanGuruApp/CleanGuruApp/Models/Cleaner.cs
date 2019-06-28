using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CleanGuruApp.Models
{
    public class Cleaner
    {
        [Key]
        public int IdCleaner{ get; set; }
        [Required(ErrorMessage = "Please enter a valid first name.")]
        public string FCleanerName{ get; set; }
        public string MCleanerName{ get; set; }
        [Required(ErrorMessage = "Please enter a valid family name.")]
        public string LCleanerName{ get; set; }
        [Required(ErrorMessage = "Please enter a valid address.")]
        public string ClAddress{ get; set; }
        [Required(ErrorMessage = "Please enter a valid Unit.")]
        public string ClAddressUnit{ get; set; }
        [Required(ErrorMessage = "Please enter a valid postal code.")]
        [StringLength(6)]
        public string ClPostalCode{ get; set; }
        [Required(ErrorMessage = "Please enter a valid city.")]
        public string ClCity{ get; set; }
        [Required(ErrorMessage = "Please enter a valid province.")]
        public string ClProvince{ get; set; }
        [Required(ErrorMessage = "Please enter a valid phone.")]
        public string ClPhone1{ get; set; }
        public string ClPhone2{ get; set; }
        public string ClSincNumber{ get; set; }                             //Sinc????
        [Range(3, 40, ErrorMessage = "Can not be empty. Please enter your user name.")]
        public string UserName{ get; set; }
    }
}
