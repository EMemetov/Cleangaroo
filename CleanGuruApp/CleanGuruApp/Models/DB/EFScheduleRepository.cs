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

        //public IQueryable<Cleaners> Cleaners => context.Cleaners.Include(c => c.Players);     //DELETE after adjust below

        public IQueryable<Appointment> Appointments => throw new NotImplementedException();            //DELETE after adjust abouve

        public void SaveAppointment(Appointment appointment)
        {
            //INSERT CODE

            context.SaveChanges();
        }
        public Appointment DeleteAppointment(int idAppointment)
        {
            //Appointment appointment = Appointment.FirstOrDefault(c => c.IdAppointment == idAppointment);       //ERROR ????

            ////INSERT CODE

            //return appointment;       //ERROR ????

            //Just to make it work
            Appointment appointment = new Appointment();
            return appointment;


        }


    }
}
