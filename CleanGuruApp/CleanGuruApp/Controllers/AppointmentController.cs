//*********************************************************************************************************************
// Author: Andrea Cavalheiro - Last Modified Date: August, 7th 2019.
// The AppointmentController receives the appointment data, validates the information and then passes it to the data model.
// 
//*********************************************************************************************************************

using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using CleanGuruApp.Models;
using CleanGuruApp.Models.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CleanGuruApp.Controllers
{
    public class AppointmentController : Controller
    {
        //declaring the repositories variables to be used in the appointment controller
        private  IAppointmentRepository  appointmentRepository;
        private  ICustomerRepository     customerRepository;
        private  ICleanerRepository      cleanerRepository;
        private  IServicePriceRepository servicePriceRepository;
        private  ICustomerSubscriptionRepository customerSubscriptionRepository;
        private  ICustomerAddressRepository customerAddressRepository;

        public AppointmentController(IAppointmentRepository appointmentRepository,
                                     ICustomerRepository customerRepository,
                                     ICleanerRepository cleanerRepository,
                                     IServicePriceRepository servicePriceRepository,
                                     ICustomerSubscriptionRepository customerSubscriptionRepository,
                                     ICustomerAddressRepository customerAddressRepository)
        {
            this.appointmentRepository = appointmentRepository;
            this.customerRepository = customerRepository;
            this.cleanerRepository = cleanerRepository;
            this.servicePriceRepository = servicePriceRepository;
            this.customerSubscriptionRepository = customerSubscriptionRepository;
            this.customerAddressRepository = customerAddressRepository;
        }
                     
        // Method to get the customer list or just one customer with the corresponding address
        // parameter "idCust", when passed to the method it will get the information about an specific customer
        private List<SelectListItem> getCustomersList(int? idCust)
        {
            List<SelectListItem> selectList = new List<SelectListItem>();
            SelectListItem item = new SelectListItem("Please select the customer", "");
            selectList.Add(item);

            if (idCust == null)
            {
                foreach (var customer in customerRepository.Customers)
                {
                    foreach (var custAddress in customerAddressRepository.CustomerAddresss.Where(c => c.IdCustomer == customer.IdCustomer))
                    {
                        customer.CustAddress = custAddress.Address + "," + custAddress.AddressUnit + " - " + custAddress.PostalCode + " - " + custAddress.City + " / " + custAddress.Province;
                    }
                    item = new SelectListItem(customer.FCustomerName + " " + 
                        customer.MCustomerName + " " + customer.LCustomerName + " [ Address: " +customer.CustAddress + " ]" , 
                        customer.IdCustomer.ToString());
                    selectList.Add(item);
                }
            }
            else
            {
                var customer = customerRepository.Customers.FirstOrDefault(c=>c.IdCustomer==idCust);
                item = new SelectListItem(customer.FCustomerName + " " + customer.MCustomerName + " " + customer.LCustomerName, customer.IdCustomer.ToString());
                selectList.Add(item);
            }

            return selectList;
        }

        //creating a method to get the cleaners list or just one cleaner
        // parameter "idClean", when passed to the method it will get the information about an specific cleaner
        private List<SelectListItem> getCleanersList(int? idClean)
        {
            List<SelectListItem> selectList = new List<SelectListItem>();
            SelectListItem item = new SelectListItem("Please select the cleaner", "");
            selectList.Add(item);
            if(idClean == null)
            {
                foreach (var cleaner in cleanerRepository.Cleaners)
                {
                    item = new SelectListItem(cleaner.FCleanerName + " " + cleaner.MCleanerName + " " + cleaner.LCleanerName, cleaner.IdCleaner.ToString());
                    selectList.Add(item);
                }
            }
            else
            {
                var cleaner = cleanerRepository.Cleaners.FirstOrDefault(c => c.IdCleaner == idClean);
                item = new SelectListItem(cleaner.LCleanerName,cleaner.FCleanerName.ToString());
                selectList.Add(item);
            }

            return selectList;
        }

        //creating a method to get the service list or just one service
        // parameter "idServ", when passed to the method it will get the information about an specific service
        private List<SelectListItem> getServiceList(int? idServ)
        {
            List<SelectListItem> selectList = new List<SelectListItem>();
            SelectListItem item = new SelectListItem("Please select the service", "");
            selectList.Add(item);

            if (idServ == null)
            {
                foreach (var servicePrice in servicePriceRepository.ServicePrices)
                {
                    item = new SelectListItem(servicePrice.ServicePriceDescr, servicePrice.IdServicePrice.ToString());
                    selectList.Add(item);
                }
            }
            else
            {
                var servicePrice = servicePriceRepository.ServicePrices.FirstOrDefault(s => s.IdServicePrice == idServ);
                item = new SelectListItem(servicePrice.ServicePriceDescr, servicePrice.IdServicePrice.ToString());
                selectList.Add(item);
            }
            return selectList;
        }

        //method to show the future appointments that corresponds to one type of user
        //parameter "typeUser", when passed to the method it will bring the appointments from that user
        public IActionResult FutureAppointment(string typeUser)
        {
            var appointment = appointmentRepository.Appointments;
            ViewBag.CustList = getCustomersList(1);
            ViewBag.CLeanList = getCleanersList(null);
            ViewBag.ServiceList = getServiceList(null);

            //foreach to calculate the total service price to be charged to the customer
            foreach (var totalItem in appointment)
            {
                totalItem.Total = totalItem.CtHoursRequested * totalItem.ServicePrice.CtAmountHour;
            }
            ViewBag.typeUser = typeUser;
            return View(appointment);
        }

        //method to create the appointment
        public ViewResult CreateAppointment()
        {
            CustomerSubscription custSub = new CustomerSubscription();
            ViewBag.period = custSub.Periodicity;
            ViewBag.finDate = DateTime.Now.ToString("yyyy-MM-dd");
            ViewBag.CustList = getCustomersList(null);
            ViewBag.CLeanList = getCleanersList(null);
            ViewBag.ServiceList = getServiceList(null);
            return View("../Appointment/CreateAppointment");
        }       
        [HttpPost]
        public IActionResult CreateAppointment(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    appointmentRepository.Add(appointment);
                    ViewBag.CustList = getCustomersList(null);
                    ViewBag.CLeanList = getCleanersList(null);
                    ViewBag.ServiceList = getServiceList(null);
                    ViewBag.finDate = DateTime.Now.ToString("yyyy-MM-dd");
                    return View("../Home/Index");
                }
                catch (Exception)
                {

                    ViewBag.CustList = getCustomersList(null);
                    ViewBag.CLeanList = getCleanersList(null);
                    ViewBag.ServiceList = getServiceList(null);
                    ViewBag.finDate = DateTime.Now.ToString("yyyy-MM-dd");
                    TempData["message"] = "Date of Service and Start Time must be greater than today's datetime !";
                    return View("CreateAppointment");
                }
            }
            else
            {
                ViewBag.CustList = getCustomersList(null);
                ViewBag.CLeanList = getCleanersList(null);
                ViewBag.ServiceList = getServiceList(null);
                ViewBag.finDate = DateTime.Now.ToString("yyyy-MM-dd");
                TempData["message"] = "Appointment was not created! Please fill all the information required!";
                return View("CreateAppointment");
            }
        }

        //method to show the details about an appointment previous selected
        //parameter "id", when passed to the method it will bring all the data from that appointments
        public IActionResult Details(int id)
        {
            var appointment = appointmentRepository.GetAppointment(id);
            ViewBag.CustList = getCustomersList(appointment.IdCustomer);
            ViewBag.ServiceList = getServiceList(appointment.IdServicePrice);
            ViewBag.CleanList = getCleanersList(appointment.IdCleaner);
            appointment.Total = appointment.CtHoursRequested * appointment.ServicePrice.CtAmountHour;
            return View(appointment);
        }

        //method to delete an appointment previous selected
        //parameter "id" to delete an specific appointment
        public IActionResult Delete(int id)
        {
            var appointment = appointmentRepository.GetAppointment(id);
            ViewBag.CustList = getCustomersList(appointment.IdCustomer);
            ViewBag.ServiceList = getServiceList(appointment.IdServicePrice);
            ViewBag.CleanList = getCleanersList(appointment.IdCleaner);
            appointment.Total = appointment.CtHoursRequested * appointment.ServicePrice.CtAmountHour;
            return View(appointment);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            customerSubscriptionRepository.DeleteCustomerSubscription(id);
            appointmentRepository.Remove(id);
            TempData["message"] = "[ID " + id + "] Appointment deleted.";
            return RedirectToAction(nameof(FutureAppointment));
        }

        //method to edit an appointment previous selected
        //parameter "id" to edit an specific appointment
        public IActionResult Edit(int id)
        {
            var appointment = appointmentRepository.GetAppointment(id);

            ViewBag.CustList = getCustomersList(null);
            ViewBag.CLeanList = getCleanersList(null);
            ViewBag.ServiceList = getServiceList(null);
            return View(appointment);
        }
        [HttpPost]
        public IActionResult Edit( int id, Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    try
                    {
                        appointmentRepository.Add(appointment);
                        customerSubscriptionRepository.DeleteCustomerSubscription(id);
                        appointmentRepository.Remove(id);
                        TempData["message"] = "[ID " + id + "] Appointment was deleted. / " + "[ID " + appointment.IdAppointment + "] A new appointment was created.";
                        return RedirectToAction(nameof(FutureAppointment));
                    }
                    catch (Exception)
                    {
                        ViewBag.CustList = getCustomersList(null);
                        ViewBag.CLeanList = getCleanersList(null);
                        ViewBag.ServiceList = getServiceList(null);
                        TempData["message"] = "Date of Service and Start Time must be greater than today's datetime !";
                        return View("Edit");
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentExists(appointment.IdAppointment))
                    {
                        return NotFound();
                    }
                    else
                    {
                      throw;
                    }
                }
            }
            ViewBag.CustList = getCustomersList(null);
            ViewBag.CLeanList = getCleanersList(null);
            ViewBag.ServiceList = getServiceList(null);
            TempData["message"] = "Appointment was not created! Please fill all the information required!";
            return View(appointment);
        }

        //method to validate if the aapointment exists
        //parameter "idAppointment" used to validate if the appointment exists
        private bool AppointmentExists(int idAppointment)
        {
            return appointmentRepository.GetAppointment(idAppointment) != null;
        }

        //method to show the appointments that belongs to the cleaners
        public ViewResult CleanerAppointment()
        {
            var appointment = appointmentRepository.Appointments;
            ViewBag.CustList = getCustomersList(1);
            ViewBag.CLeanList = getCleanersList(null);
            ViewBag.ServiceList = getServiceList(null);
            foreach (var totalItem in appointment)
            {
                totalItem.Total = totalItem.CtHoursRequested * totalItem.ServicePrice.CtAmountHour;
            }
            return View(appointment);
        }

        //method to decline an appointment by the cleaner
        //parameter "id" used to decline an specific appointment
        public ViewResult Decline(int id)
        {
            var appointment = appointmentRepository.GetAppointment(id);
            ViewBag.CustList = getCustomersList(1);
            ViewBag.CLeanList = getCleanersList(null);
            ViewBag.ServiceList = getServiceList(null);
            return View(appointment);
        }

    }
}
