using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanGuruApp.Models
{
    public class CleanersRate
    {
        public int IdRate{ get; set; }
        public int IdSchedule{ get; set; }
        public int IdCleaner{ get; set; }
        public string CleanerRate{ get; set; }              //should it be double?
    }
}
