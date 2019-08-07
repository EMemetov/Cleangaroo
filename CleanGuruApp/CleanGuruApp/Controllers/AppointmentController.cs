using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using CleanGuruApp.Models;
using CleanGuruApp.Models.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CleanGuruApp.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentRepository appointmentRepository;
        private readonly ICustomerRepository customerRepository;
        private readonly ICleanerRepository cleanerRepository;
        private readonly IServicePriceRepository servicePriceRepository;
        private readonly ICustomerSubscriptionRepository customerSubscriptionRepository;
        private readonly ICustomerAddressRepository customerAddressRepository;

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

        public IActionResult FutureAppointment(string typeUser)
        {
            var appointment = appointmentRepository.Appointments;
            ViewBag.CustList = getCustomersList(1);
            ViewBag.CLeanList = getCleanersList(null);
            ViewBag.ServiceList = getServiceList(null);
            foreach (var totalItem in appointment)
            {
                totalItem.Total = totalItem.CtHoursRequested * totalItem.ServicePrice.CtAmountHour;
            }
            ViewBag.typeUser = typeUser;
            return View(appointment);
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

        public IActionResult Details(int id)
        {
            var appointment = appointmentRepository.GetAppointment(id);
            ViewBag.CustList = getCustomersList(appointment.IdCustomer);
            ViewBag.ServiceList = getServiceList(appointment.IdServicePrice);
            ViewBag.CleanList = getCleanersList(appointment.IdCleaner);
            appointment.Total = appointment.CtHoursRequested * appointment.ServicePrice.CtAmountHour;
            return View(appointment);
        }

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

        private bool AppointmentExists(int idAppointment)
        {
            return appointmentRepository.GetAppointment(idAppointment) != null;
        }

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
