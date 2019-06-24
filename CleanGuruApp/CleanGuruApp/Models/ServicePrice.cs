using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanGuruApp.Models
{
    public class ServicePrice
    {
        public int IdServicePrice { get; set; }
        public double CtAmountHour { get; set; }
        public double ClAmountHour { get; set; }
        public bool ServicePriceStatus { get; set; }
    }
}
