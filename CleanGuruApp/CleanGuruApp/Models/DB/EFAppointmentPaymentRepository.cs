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

        public IQueryable<AppointmentPayment> AppointmentPayments => context.AppointmentPayment;

        public void SaveAppointmentPayment(AppointmentPayment appointmentPayment)
        {
            if (appointmentPayment.IdAppointmentPayment == 0)
            {
                context.AppointmentPayment.Add(appointmentPayment);
            }
            else
            {
                AppointmentPayment dbEntry = context.AppointmentPayment.
                    FirstOrDefault(a => a.IdAppointmentPayment == appointmentPayment.IdAppointmentPayment);
                if (dbEntry != null)
                {
                    dbEntry.IdAppointment = appointmentPayment.IdAppointment;
                    dbEntry.CtHoursContracted = appointmentPayment.CtHoursContracted;
                    dbEntry.ClHoursWorked = appointmentPayment.ClHoursWorked;
                    dbEntry.PaidByCustomer = appointmentPayment.PaidByCustomer;
                    dbEntry.PaidToCleaner = appointmentPayment.PaidToCleaner;
                    dbEntry.AmountPaidByCustomer = appointmentPayment.AmountPaidByCustomer;
                    dbEntry.AmountPaidToCleaner = appointmentPayment.AmountPaidToCleaner; 
                }
            }
            context.SaveChanges();
        }
        //public void DeleteAppointmentPayment(int idAppointmentPayment)
        //{
        //    AppointmentPayment dbEntry = context.AppointmentPayment.
        //        FirstOrDefault(a => a.IdAppointmentPayment == idAppointmentPayment);
        //    if (dbEntry != null)
        //    {
        //        context.AppointmentPayment.Remove(dbEntry);
        //        context.SaveChanges();
        //    }
        //}
    }
}
