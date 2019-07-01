using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanGuruApp.Models;
using CleanGuruApp.Models.DB;
using Microsoft.AspNetCore.Mvc;

namespace CleanGuruApp.Controllers
{
    public class AppointmentController : Controller
    {
        private IAppointmentRepository repository;

        public AppointmentController(IAppointmentRepository repo)
        {
            repository = repo;
        }

        //Show list of Appointments
        public IActionResult List()
        {
            return View(repository.Appointments);
        }

        public IActionResult Add() => View("CreateAppointment", new Appointment());     //Change view's name to Appointment, this way can be to create or edit

        [HttpGet]
        public IActionResult Edit(int idAppointment) => View(repository.Appointments.FirstOrDefault(c => c.IdAppointment == idAppointment));
        //public IActionResult CreateAppointment(int idAppointment) => View(repository.Appointments.FirstOrDefault(c => c.IdAppointment == idAppointment));

        [HttpPost]
        public IActionResult Edit(Appointment appointment)
        {
            Console.WriteLine("Usuario: " + appointment.IdAppointment);
            Console.WriteLine("Usuario: " + appointment.CtHoursRequested);
            Console.WriteLine("Usuario: " + appointment.CtDateRequestService);
            Console.WriteLine("Usuario: " + appointment.CleanerRate);
            Console.WriteLine("Usuario: " + appointment.IdCleaner);
            if (ModelState.IsValid)
            {
                repository.SaveAppointment(appointment);
                TempData["message"] = "Appointment has been saved.";
                return RedirectToAction("List");
            }
            else
            {
                return View("../Home/Index");
            }
        }




        ////WORKING
        //public String Edit(Appointment appointment)                // = Edit in C229_GS2G3
        //{
        //    Console.WriteLine("Usuario: " + appointment.CleanerRate);
        //        Console.WriteLine("Usuario: " + appointment.CtHoursRequested);
        //        Console.WriteLine("Usuario: " + appointment.CtDateRequestService);
        //    if (ModelState.IsValid)
        //    {
        //        return "Valid Model";               //ALWAYS ????????
        //    }
        //    else
        //    {
        //        return "Invalid Model";
        //    }
        //}

        //public ViewResult EditAppointment()                // = Edit in C229_GS2G3
        //{
        //    if (ModelState.IsValid)
        //    {
        //        return View("CreateUser");
        //    }
        //    else
        //    {
        //        return View();
        //    }
        //}

        ////[HttpPost]
        //public IActionResult EditAppointment(Appointment appointment)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //repository.SaveAppointment(appointment);
        //        TempData["message"] = "Appointment has been saved.";
        //        //return RedirectToAction("Index");
        //        return View("../Home/Index");
        //    }
        //    else
        //    {
        //        return View("CreateAppointment");           //Change view's name to Appointment, this way can be to create or edit
        //    }
        //}






    }
}