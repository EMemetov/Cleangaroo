using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanGuruApp.Models.DB
{
    public interface IAppointmentRepository
    {
        //IQueryable<Appointment> Appointments { get; }
        ////void DeleteAppointment(int idAppointment);

        IEnumerable<Appointment> Appointments { get; }
        void Add(Appointment appointment);
        void Save(Appointment appointment);
        Appointment GetAppointment(int? idAppointment);

    }
}
