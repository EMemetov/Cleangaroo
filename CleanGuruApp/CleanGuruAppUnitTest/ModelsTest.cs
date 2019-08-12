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




        //---
        [Fact]
        public void VerifyCustomerAddressidCustAddress()
        {
            var customerAddress  = new CustomerAddress();
            

            int result = 22;

            customerAddress.idCustAddress = 22;

            Assert.Equal(customerAddress.idCustAddress, result);

        }


        [Fact]
        public void VerifyCustomerAddressidCustAddressType()
        {
            var customerAddress = new CustomerAddress();

            Assert.IsType<int>(customerAddress.idCustAddress);
        }      

        [Fact]
        public void VerifyCustomerAddressIdCustomerAddressType()
        {
            var customerAddress = new CustomerAddress();

            Assert.IsType<int>(customerAddress.idCustAddress);
        }
        [Fact]
        public void VerifyCustomerAddressAddressType()
        {
            var customerAddress = new CustomerAddress();
            customerAddress.Address = "address";

            Assert.IsType<string>(customerAddress.Address);
        }

        [Fact]
        public void VerifyCustomerAddressAddress()
        {
            var customerAddress = new CustomerAddress();


            string result = "110 bay st";

            customerAddress.Address = result;

            Assert.Equal(customerAddress.Address, result);

        }

    }
}
