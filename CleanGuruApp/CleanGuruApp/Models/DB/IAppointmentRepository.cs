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
        void Remove(Appointment appointment);
        void Remove(int idAppointment);
        void Update(Appointment appointment);
        // void Update(int idAppointment, int idCleaner);
        Appointment GetAppointment(int? idAppointment);

    }
}
