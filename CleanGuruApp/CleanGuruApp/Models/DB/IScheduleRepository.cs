using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanGuruApp.Models.DB
{
    public interface IAppointmentRepository
    {
        IQueryable<Appointment> Appointments { get; }
        void SaveAppointment(Appointment appointment);

        Appointment DeleteAppointment(int idAppointment);
    }
}
