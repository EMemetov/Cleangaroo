using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanGuruApp.Models.DB
{
    public class EFSchedulePaymentRepository : ISchedulePaymentRepository
    {
        private ApplicationDBContext context;

        public EFSchedulePaymentRepository(ApplicationDBContext context)
        {
            this.context = context;
        }

        //public IQueryable<SchedulePayment> SchedulePayment => context.SchedulePayment.Include(c => c.Players);     //DELETE after adjust below

        public IQueryable<SchedulePayment> SchedulePayments => throw new NotImplementedException();            //DELETE after adjust abouvepublic IQueryable<SchedulePayment> SchedulePayments => throw new NotImplementedException();

        public void SaveSchedulePayment(SchedulePayment schedulePayments)
        {
            //INSERT CODE

            context.SaveChanges();
        }
        public SchedulePayment DeleteSchedulePayment(int idSchedulePayment)
        {
            //SchedulePayment cleaner = SchedulePayment.FirstOrDefault(c => c.IdCleaner == idCleaner);

            ////INSERT CODE

            //return cleaner;

            //Just to make it work
            SchedulePayment schedulePayment = new SchedulePayment();
            return schedulePayment;


        }


    }
}
