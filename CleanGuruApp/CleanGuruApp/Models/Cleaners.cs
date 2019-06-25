using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanGuruApp.Models
{
    public class Cleaners
    {
        public int IdCleaner{ get; set; }
        public string FCleanerName{ get; set; }
        public string MCleanerName{ get; set; }
        public string LCleanerName{ get; set; }
        public string ClAddress{ get; set; }
        public string ClAddressUnit{ get; set; }
        public string ClPostalCode{ get; set; }
        public string ClCity{ get; set; }
        public string ClProvince{ get; set; }
        public string ClPhone1{ get; set; }
        public string ClPhone2{ get; set; }
        public string ClSincNumber{ get; set; }
        public string UserName{ get; set; } /*maria*/
    }
}
