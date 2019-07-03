using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanGuruApp.Models.DB
{
    public interface IAppointmentPaymentRepository
    {
        IQueryable<AppointmentPayment> AppointmentPayments { get; }
        void SaveAppointmentPayment(AppointmentPayment appointmentPayments);

        //void DeleteAppointmentPayment(int idAppointmentPayment);
    }
}
