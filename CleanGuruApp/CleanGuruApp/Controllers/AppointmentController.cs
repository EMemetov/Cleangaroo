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

        public IActionResult List()
        {
            return View(repository.Appointments);
        }

        public IActionResult Add() => View("CreateAppointment", new Appointment());     //Change view's name to Appointment, this way can be to create or edit

        //[HttpGet]
        //public IActionResult EditAppontment(int idAppointment) => View(repository.Appointments.FirstOrDefault(c => c.IdAppointment == idAppointment));

        //[HttpPost]
        public ViewResult CreateAppointment()
        {
            return View();
        }

        ////WORKING
        //public String EditAppointment()                // = Edit in C229_GS2G3
        //{
        //    if (ModelState.IsValid)
        //    {
        //        return "Valid Model";               //ALWAYS ????????
        //    }
        //    else
        //    {
        //        return "Invalid Model";
        //    }
        //}

        public ViewResult EditAppointment()                // = Edit in C229_GS2G3
        {
            if (ModelState.IsValid)
            {
                return View("CreateUser");
            }
            else
            {
                return View();
            }
        }

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