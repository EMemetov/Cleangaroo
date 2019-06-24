using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanGuruApp.Models
{
    public class CustomerAddress
    {
        public int IdCustAddress { get; set; }
        public int IdCustomer { get; set; }
        public string Address { get; set; }
        public string AddressUnit { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string UserName{ get; set; }
    }
}
