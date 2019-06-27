using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanGuruApp.Models.DB
{
    public class EFAppointmentPaymentRepository : IAppointmentPaymentRepository
    {
        private ApplicationDBContext context;

        public EFAppointmentPaymentRepository(ApplicationDBContext context)
        {
            this.context = context;
        }

        public IQueryable<AppointmentPayment> AppointmentPayments => throw new NotImplementedException();            //DELETE after adjust abouvepublic IQueryable<AppointmentPayment> AppointmentPayments => throw new NotImplementedException();

        public void SaveAppointmentPayment(AppointmentPayment appointmentPayments)
        {
            //INSERT CODE

            context.SaveChanges();
        }
        public void DeleteAppointmentPayment(int idAppointmentPayment)
        {
            //AppointmentPayment cleaner = AppointmentPayment.FirstOrDefault(c => c.IdCleaner == idCleaner);

            ////INSERT CODE

            //return cleaner;

            //Just to make it work


        }


    }
}
