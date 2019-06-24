using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanGuruApp.Models
{
    public class CustomerSubscription
    {
        public int IdSubscription{ get; set ;}
        public int IdCustomer{ get; set ;}
        public char Subscription{ get; set ;}
        public string Periodicity{ get; set ;}
        public DateTime FinishDate{ get; set ;}
    }
}
