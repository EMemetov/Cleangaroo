using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanGuruApp.Models
{
    public class CustomerAddress
    {
        public int idcustaddress { get; set; }
        public int idcustomer { get; set; }
        public string address { get; set; }
        public string addressunit { get; set; }
        public string postalcode { get; set; }
        public string city { get; set; }
        public string province { get; set; }
        public string UserName{ get; set; }
    }
}
