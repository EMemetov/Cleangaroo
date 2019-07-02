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

            Appointment dbEntry = context.Appointment.FirstOrDefault(u => u.IdAppointment == appointment.IdAppointment);
            if (dbEntry == null)
            {
                context.Appointment.Add(appointment);
            }
            else
            {
                //<<<<<<< HEAD
                //                dbEntry.CtDateRequestService = appointment.CtDateRequestService;
                //                dbEntry.CtHoursRequested = appointment.CtHoursRequested;
                //                dbEntry.StartTime = appointment.StartTime;
                //                dbEntry.IsSubscription = appointment.IsSubscription;
                //                dbEntry.CleanerRate = appointment.CleanerRate;

                //                //Hardcode for now due to Foreign Key
                //                dbEntry.IdCleaner = 4;
                //                dbEntry.IdCustomer = 4;
                //                dbEntry.IdServicePrice = 4;
                //            }
                //            context.SaveChanges();
                //=======
                //                Appointment dbEntry = context.Appointment.
                //                    FirstOrDefault(a => a.IdAppointment == appointment.IdAppointment);
                //                if (dbEntry != null)
                //               {
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
            }
            context.SaveChanges();
        }
        

//        public void DeleteAppointment(int idAppointment)
//        {
//            //Appointment dbEntry = context.Appointment.
//            //    FirstOrDefault(a => a.IdAppointment == idAppointment);
//            //if (dbEntry != null)
//            //{
//            //    context.Appointment.Remove(dbEntry);
//            //    context.SaveChanges();
//            //}
//>>>>>>> 83d7e62a8ef542be267b8eceb0eae245c31e8706
//        }
    }
}
