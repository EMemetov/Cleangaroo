using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CleanGuruApp.Models
{
    public class Cleaners
    {
        [Key]
        public int IdCleaner{ get; set; }
        [Required(ErrorMessage ="The cleaner first name should be not blank")]
        public string FCleanerName{ get; set; }
        public string MCleanerName{ get; set; }
        public string LCleanerName{ get; set; }
        public string ClAddress{ get; set; }
        public string ClAddressUnit{ get; set; }
        [StringLength(6)]
        public string ClPostalCode{ get; set; }
        public string ClCity{ get; set; }
        public string ClProvince{ get; set; }
        [Required(ErrorMessage = "The phone 1 should be not blank")]
        public string ClPhone1{ get; set; }
        public string ClPhone2{ get; set; }
        public string ClSincNumber{ get; set; }
        [Required(ErrorMessage = "The user name should be not blank")]
        [StringLength(40)]
        public string UserName{ get; set; }
    }
}
