using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanGuruApp.Models.DB
{
    public class EFAppointmentRepository : IAppointmentRepository
    {
        private ApplicationDBContext context;

        public EFAppointmentRepository(ApplicationDBContext context)
        {
            this.context = context;
        }

        public IQueryable<Appointment> Appointments => context.Appointment;

        public void SaveAppointment(Appointment appointment)
        {
            if (appointment.IdAppointment == 0)
            {
                context.Appointment.Add(appointment);
            }
            else
            {
                Appointment dbEntry = context.Appointment.
                    FirstOrDefault(a => a.IdAppointment == appointment.IdAppointment);
                if (dbEntry != null)
                {
                    dbEntry.IdServicePrice = appointment.IdServicePrice;
                    dbEntry.IdCustomer = appointment.IdCustomer;
                    dbEntry.CtDateRequestService = appointment.CtDateRequestService;
                    dbEntry.CtHoursRequested = appointment.CtHoursRequested;
                    dbEntry.ClockIn = appointment.ClockIn;
                    dbEntry.IdCleaner = appointment.IdCleaner;
                    dbEntry.ClockOut = appointment.ClockOut;
                    dbEntry.CleanerRate = appointment.CleanerRate;
                    dbEntry.startTime = appointment.startTime;
                    dbEntry.isSubscription = appointment.isSubscription;
                }
            }
            context.SaveChanges();
        }
        public void DeleteAppointment(int idAppointment)
        {
            //Appointment dbEntry = context.Appointment.
            //    FirstOrDefault(a => a.IdAppointment == idAppointment);
            //if (dbEntry != null)
            //{
            //    context.Appointment.Remove(dbEntry);
            //    context.SaveChanges();
            //}
        }
    }
}
