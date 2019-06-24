using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanGuruApp.Models.DB
{
    public interface ISchedulePaymentRepository
    {
        IQueryable<SchedulePayment> SchedulePayments { get; }
        void SaveSchedulePayment(SchedulePayment schedulePayments);

        SchedulePayment DeleteSchedulePayment(int idSchedulePayment);
    }
}
