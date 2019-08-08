//*********************************************************************************************************************
// Author: Theo Mitchel - Last Modified Date: August, 7th 2019.  
// Declaring the methods to be used for the EFAppointmentPaymentRepository
//*********************************************************************************************************************
using System.Linq;

namespace CleanGuruApp.Models.DB
{
    public interface IAppointmentPaymentRepository
    {
        IQueryable<AppointmentPayment> AppointmentPayments { get; }
        void SaveAppointmentPayment(AppointmentPayment appointmentPayments);
    }
}
