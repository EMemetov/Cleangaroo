using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

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

        public void Add(Appointment appointment)
        {
            context.Appointment.Add(appointment);
            context.SaveChanges();
        }

        public Appointment GetAppointment(int? idAppointment)
        {
            if (idAppointment == null) return null;

            var appointment = context.Appointment.Include(p => p.Customer).Where(p => p.IdAppointment == idAppointment).FirstOrDefault();

            return appointment;

        }

        public void Remove(Appointment appointment)
        {
            context.Appointment.Remove(appointment);
            context.SaveChanges();

        }

        public void Remove(int id)
        {
            Remove(GetAppointment(id));
        }

        //public void Update(int id, int idCleaner)
        //{

        //    Appointment dbEntry = context.Appointment.FirstOrDefault(u => u.IdAppointment == id);
        //    dbEntry.IdCleaner = idCleaner;
        //    context.SaveChanges();
        //}

        public void Update(Appointment appointment)
        {
            context.Appointment.Update(appointment);
            context.SaveChanges();
        }


        public void Save(Appointment appointment)
        {
            Appointment dbEntry = context.Appointment.FirstOrDefault(u => u.IdAppointment == appointment.IdAppointment);
            
            //ORIGINAL - working
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
                    //dbEntry.CustSub.IdAppointment = appointment.IdAppointment;
                    //context.Appointment.Add(appointment);
                //}else
                //{
                
                }

            }
            context.SaveChanges();
        }

        //public void DeleteAppointment(int idAppointment)
        //{
        //    Appointment dbEntry = context.Appointment.
        //        FirstOrDefault(a => a.IdAppointment == idAppointment);
        //    if (dbEntry != null)
        //    {
        //        context.Appointment.Remove(dbEntry);
        //        context.SaveChanges();
        //    }
        //}

    }

    //public class EFAppointmentRepository : IAppointmentRepository
    //{
    //    private ApplicationDBContext context;

    //    public EFAppointmentRepository(ApplicationDBContext context)
    //    {
    //        this.context = context;
    //    }

    //    public IQueryable<Appointment> Appointments => context.Appointment;

    //    public void SaveAppointment(Appointment appointment)
    //    {

    //        Appointment dbEntry = context.Appointment.FirstOrDefault(u => u.IdAppointment == appointment.IdAppointment);
    //        //ORIGINAL - working
    //        if (dbEntry == null)
    //        {
    //            context.Appointment.Add(appointment);
    //        }
    //        else
    //        {
    //            dbEntry.IdServicePrice = appointment.IdServicePrice;
    //            dbEntry.IdCustomer = appointment.IdCustomer;
    //            dbEntry.CtDateRequestService = appointment.CtDateRequestService;
    //            dbEntry.CtHoursRequested = appointment.CtHoursRequested;
    //            dbEntry.ClockIn = appointment.ClockIn;
    //            dbEntry.IdCleaner = appointment.IdCleaner;
    //            dbEntry.ClockOut = appointment.ClockOut;
    //            dbEntry.CleanerRate = appointment.CleanerRate;
    //            dbEntry.StartTime = appointment.StartTime;
    //            dbEntry.IsSubscription = appointment.IsSubscription;

    //            if (dbEntry.IsSubscription == '1')  //No subscription requested
    //            {

    //                dbEntry.CustSub.Periodicity = appointment.CustSub.Periodicity;
    //                dbEntry.CustSub.FinishDate = appointment.CustSub.FinishDate;
    //                //dbEntry.CustSub.IdAppointment = appointment.IdAppointment;
    //                //context.Appointment.Add(appointment);
    //            }

    //        }
    //        context.SaveChanges();
    //    }


    //    //        public void DeleteAppointment(int idAppointment)
    //    //        {
    //    //            //Appointment dbEntry = context.Appointment.
    //    //            //    FirstOrDefault(a => a.IdAppointment == idAppointment);
    //    //            //if (dbEntry != null)
    //    //            //{
    //    //            //    context.Appointment.Remove(dbEntry);
    //    //            //    context.SaveChanges();
    //    //            //}
    //    //        }
    //}
}
