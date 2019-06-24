﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanGuruApp.Models
{
    public class SchedulePayment
    {
        public int IdSchedulePayment{ get; set ; }
        public int IdSchedule{ get; set ; }
        public int IdCustomer{ get; set ;}
        public int CtHoursContracted{ get; set ;}
        public char PaidByCustomer{ get; set ;}
        public double AmountPaidByCustomer{ get; set ;}
        public int IdCleaner{ get; set ;}
        public char PaidToCleaner{ get; set ;}
        public int ClHoursWorked{ get; set ;}
        public double AmountPaidToCleaner{ get; set ;}
    }
}
