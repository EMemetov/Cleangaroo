using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CleanGuruApp.Models.DB
{

    public class EFAppointmentRepository : IAppointmentRepository
    {
        private ApplicationDBContext context;

        public EFAppointmentRepository(ApplicationDBContext ctx)
        {
            this.context = ctx;
        }

        public IEnumerable<Appointment> Appointments => context.Appointment.Include(p => p.Customer).ToList();

        //method used to save the appointments
        public void Add(Appointment appointment)
        {
            DateTime todayDate = DateTime.Now;

            if (appointment.CtDateRequestService > todayDate)
                {
                    context.Appointment.Add(appointment);
                    context.SaveChanges();
                }
                else
            {
                InvalidDate();
            }
         }

        private void InvalidDate()
        {
            throw new NotImplementedException("DateRequestService and StartTime must be greater than today's date !");
        }

        //method used to get the appointments data
        public Appointment GetAppointment(int? idAppointment)
        {
            if (idAppointment == null) return null;

            var appointment = context.Appointment.Include(p => p.Customer).Where(p => p.IdAppointment == idAppointment).FirstOrDefault();

            return appointment;

        }

        //method used to remove the appointments data
        public void Remove(Appointment appointment)
        {
            context.Appointment.Remove(appointment);
            context.SaveChanges();

        }
        public void Remove(int id)
        {
            Remove(GetAppointment(id));
        }

        //method used to update the appointments data
        public void Update(Appointment appointment)
        {
            context.Appointment.Update(appointment);
            context.SaveChanges();
        }

        //method used to save the appointments data
        public void Save(Appointment appointment)
        {
            Appointment dbEntry = context.Appointment.FirstOrDefault(u => u.IdAppointment == appointment.IdAppointment);
            
            if (dbEntry == null)
            {
                context.Appointment.Add(appointment);
            }
            else
            {
                dbEntry.IdServicePrice = appointment.IdServicePrice;
                dbEntry.IdCustomer = appointment.IdCustomer;
                dbEntry.CtDateRequestService = appointment.CtDateRequestService;
                dbEntry.CtHoursRequested = appointment.CtHoursRequested;
                dbEntry.ClockIn = appointment.ClockIn;
                dbEntry.IdCleaner = appointment.IdCleaner;
                dbEntry.ClockOut = appointment.ClockOut;
                dbEntry.CleanerRate = appointment.CleanerRate;
                dbEntry.StartTime = appointment.StartTime;
                dbEntry.IsSubscription = appointment.IsSubscription;

                if (dbEntry.IsSubscription == true)  //No subscription requested
                {

                    dbEntry.CustSub.Periodicity = appointment.CustSub.Periodicity;
                    dbEntry.CustSub.FinishDate = appointment.CustSub.FinishDate;
                
                }

            }
            context.SaveChanges();
        }      
    }   
}
