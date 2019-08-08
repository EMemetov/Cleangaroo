//*********************************************************************************************************************
// Author: Andrea Cavalheiro - Last Modified Date: August, 7th 2019.  
// Declaring the methods to be used for the EFAppointmentRepository
//*********************************************************************************************************************
using System.Collections.Generic;

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
