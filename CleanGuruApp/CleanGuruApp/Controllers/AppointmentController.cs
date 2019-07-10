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

        public AppointmentController(IAppointmentRepository appointmentRepository,
                                     ICustomerRepository customerRepository,
                                     ICleanerRepository cleanerRepository,
                                     IServicePriceRepository servicePriceRepository)
        {
            this.appointmentRepository = appointmentRepository;
            this.customerRepository = customerRepository;
            this.cleanerRepository = cleanerRepository;
            this.servicePriceRepository = servicePriceRepository;
        }

        public IActionResult ServiceList()
        {
            var appointment = appointmentRepository.Appointments;

            return View(appointment);
        }
        public IActionResult Details(int id)
        {
            var appointment = appointmentRepository.GetAppointment(id);

            return View(appointment);
        }

        public IActionResult Delete(int id)
        {
            var appointment = appointmentRepository.GetAppointment(id);

            return View(appointment);
        }


        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            appointmentRepository.Remove(id);
            return RedirectToAction(nameof(ServiceList));
        }



        public IActionResult List()
        {
            var appointment = appointmentRepository.Appointments;

            return View(appointment);
        }



        private List<SelectListItem> getCustomersList()
        {
            List<SelectListItem> selectList = new List<SelectListItem>();
            SelectListItem item = new SelectListItem("Please select the customer", "");
            selectList.Add(item);

            foreach (var customer in customerRepository.Customers)
            {
                item = new SelectListItem(customer.FCustomerName + " " + customer.MCustomerName + " " + customer.LCustomerName, customer.IdCustomer.ToString());
                selectList.Add(item);
            }

            return selectList;
        }

        private List<SelectListItem> getCleanersList()
        {
            List<SelectListItem> selectList = new List<SelectListItem>();
            SelectListItem item = new SelectListItem("Please select the cleaner", "");
            selectList.Add(item);

            foreach (var cleaner in cleanerRepository.Cleaners)
            {
                item = new SelectListItem(cleaner.FCleanerName + " " + cleaner.MCleanerName + " " + cleaner.LCleanerName, cleaner.IdCleaner.ToString());
                selectList.Add(item);
            }

            return selectList;
        }


        private List<SelectListItem> getServiceList()
        {
            List<SelectListItem> selectList = new List<SelectListItem>();
            SelectListItem item = new SelectListItem("Please select the service", "");
            selectList.Add(item);

            foreach (var servicePrice in servicePriceRepository.ServicePrices)
            {
                item = new SelectListItem(servicePrice.ServicePriceDescr, servicePrice.IdServicePrice.ToString());
                selectList.Add(item);
            }

            return selectList;
        }

        public ViewResult CreateAppointment()
        {
            CustomerSubscription custSub = new CustomerSubscription();
            ViewBag.period = custSub.Periodicity;
            ViewBag.finDate = custSub.FinishDate;
            ViewBag.CustList = getCustomersList();
            ViewBag.CLeanList = getCleanersList();
            ViewBag.ServiceList = getServiceList();
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
                    ViewBag.CustList = getCustomersList();
                    ViewBag.CLeanList = getCleanersList();
                    ViewBag.ServiceList = getServiceList();
                    TempData["message"] = "Appointment has been saved.";
                    return View("../Home/Index");
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                ViewBag.CustList = getCustomersList();
                ViewBag.CLeanList = getCleanersList();
                ViewBag.ServiceList = getServiceList();
                return View("../Home/Index");
            }
        }
    }
}


    //    public class AppointmentController : Controller
    //    {
    //        private IAppointmentRepository repository;

    //        public AppointmentController(IAppointmentRepository repo)
    //        {
    //            repository = repo;
    //        }

    //        // GET: MemberInfoes
    //        public async Task<IActionResult> Index()
    //        {
    //            return View(await repository.Appointments.ToListAsync());
    //        }

    //        //Show list of Appointments
    //        public IActionResult List()
    //        {
    //            return View(repository.Appointments);
    //        }

    //        public IActionResult Add() => View("CreateAppointment", new Appointment());     //Change view's name to Appointment, this way can be to create or edit

    //        [HttpGet]
    //        public IActionResult Edit(int idAppointment) => View(repository.Appointments.FirstOrDefault(c => c.IdAppointment == idAppointment));
    //        //public IActionResult CreateAppointment(int idAppointment) => View(repository.Appointments.FirstOrDefault(c => c.IdAppointment == idAppointment));

    //        [HttpPost]
    //        public IActionResult Edit(Appointment appointment, CustomerSubscription custmSubs)
    //        {
    //            Console.WriteLine("IdAppointment: " + appointment.IdAppointment);
    //            Console.WriteLine("IdCustomer: " + appointment.IdCustomer);
    //            Console.WriteLine("IdCleaner: " + appointment.IdCleaner);
    //            Console.WriteLine("IdServicePrice: " + appointment.IdServicePrice);
    //            Console.WriteLine("CtHoursRequested: " + appointment.CtHoursRequested);
    //            Console.WriteLine("CtDateRequestService: " + appointment.CtDateRequestService);
    //            Console.WriteLine("CleanerRate: " + appointment.CleanerRate);
    //            Console.WriteLine("IsSubscription: " + appointment.IsSubscription);
    //            Console.WriteLine("IsSubscriptionCheck: " + appointment.IsSubscriptionCheck);
    //            Console.WriteLine("Period: " + appointment.CustSub.Periodicity);
    //            Console.WriteLine("Fin Date: " + appointment.CustSub.FinishDate);
    //            Console.WriteLine("IdAppointment: " + appointment.CustSub.IdAppointment);
    ////            repository.SaveAppointment(appointment);
    //            if (ModelState.IsValid)
    //            {
    //                try
    //                {
    //                    Console.WriteLine("Entrou");
    //                    repository.SaveAppointment(appointment);
    //                    Console.WriteLine("Saiu");
    //                }
    //                catch (Exception)
    //                {
    //                    throw;
    //                }

    //                TempData["message"] = "Appointment has been saved.";
    //                //return RedirectToAction("List");
    //                return View("../Home/Index");
    //            }
    //            else
    //            {
    //                return View("../Home/Index");
    //            }
    //        }




    //        ////WORKING
    //        //public String Edit(Appointment appointment)                // = Edit in C229_GS2G3
    //        //{
    //        //    Console.WriteLine("Usuario: " + appointment.CleanerRate);
    //        //        Console.WriteLine("Usuario: " + appointment.CtHoursRequested);
    //        //        Console.WriteLine("Usuario: " + appointment.CtDateRequestService);
    //        //    if (ModelState.IsValid)
    //        //    {
    //        //        return "Valid Model";               //ALWAYS ????????
    //        //    }
    //        //    else
    //        //    {
    //        //        return "Invalid Model";
    //        //    }
    //        //}

    //        //public ViewResult EditAppointment()                // = Edit in C229_GS2G3
    //        //{
    //        //    if (ModelState.IsValid)
    //        //    {
    //        //        return View("CreateUser");
    //        //    }
    //        //    else
    //        //    {
    //        //        return View();
    //        //    }
    //        //}

    //        ////[HttpPost]
    //        //public IActionResult EditAppointment(Appointment appointment)
    //        //{
    //        //    if (ModelState.IsValid)
    //        //    {
    //        //        //repository.SaveAppointment(appointment);
    //        //        TempData["message"] = "Appointment has been saved.";
    //        //        //return RedirectToAction("Index");
    //        //        return View("../Home/Index");
    //        //    }
    //        //    else
    //        //    {
    //        //        return View("CreateAppointment");           //Change view's name to Appointment, this way can be to create or edit
    //        //    }
    //        //}
    //    }
//}