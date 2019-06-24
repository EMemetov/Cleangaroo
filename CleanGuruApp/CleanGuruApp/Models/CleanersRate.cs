using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanGuruApp.Models
{
    public class CleanersRate
    {
        public int idrate{ get; set };
        public int idschedule{ get; set };
        public int idcleaner{ get; set };
        public string cleanerrate{ get; set };              //should it be double?
    }
}
