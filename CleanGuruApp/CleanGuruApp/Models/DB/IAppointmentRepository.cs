using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanGuruApp.Models.DB
{
    public interface IAppointmentRepository
    {
        IEnumerable<Appointment> Appointments { get; }
        void Add(Appointment appointment);
        void Save(Appointment appointment);
        void Remove(Appointment appointment);
        void Remove(int idAppointment);
        void Update(Appointment appointment);
        Appointment GetAppointment(int? idAppointment);

    }
}
