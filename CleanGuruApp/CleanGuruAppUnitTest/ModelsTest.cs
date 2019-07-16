using System;
using Xunit;
using CleanGuruApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CleanGuruAppUnitTest
{
    public class ModelsTest
    {
        [Fact]
        public void VerifyIdAppointment()
        {
            var appointment = new Appointment();

            int result = 20;

            appointment.IdAppointment = 20;


            Assert.Equal(appointment.IdAppointment, result);

        }

        [Fact]
        public void VerifyIdAppointmentType()
        {
            var appointment = new Appointment();
     
            Assert.IsType<int>(appointment.IdAppointment);

        }

        [Fact]
        public void VerifyIdServicePrice()
        {
            var appointment = new Appointment();

            int result = 13;

            appointment.IdServicePrice = 13;


            Assert.Equal(appointment.IdServicePrice, result);

        }


        [Fact]
        public void VerifyIdServicePriceType()
        {
            var appointment = new Appointment();   

            Assert.IsType<int>(appointment.IdServicePrice);

        }


        [Fact]
        public void VerifyAppointmentPaymentIdAppointmentPayment()
        {
            var appointmentPayment = new AppointmentPayment();

            int result = 13;

            appointmentPayment.IdAppointmentPayment = 13;


            Assert.Equal(appointmentPayment.IdAppointmentPayment, result);

        }

        [Fact]
        public void VerifyAppointmentPaymentIdAppointmentPaymentType()
        {
            var appointmentPayment = new AppointmentPayment();

            Assert.IsType<int>(appointmentPayment.IdAppointmentPayment);

        }

        [Fact]
        public void VerifyAppointmentPaymentIdAppointment()
        {
            var appointmentPayment = new AppointmentPayment();
            var appointment = new Appointment();

            int result = 22;

            appointment.IdAppointment = 22;


         

            appointmentPayment.IdAppointment = appointment.IdAppointment;


            Assert.Equal(appointmentPayment.IdAppointment, result);

        }

        [Fact]
        public void VerifyAppointmentPaymentIdAppointmentType()
        {
            var appointmentPayment = new AppointmentPayment();

            Assert.IsType<int>(appointmentPayment.IdAppointment);

        }


    }
}
