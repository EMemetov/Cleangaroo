using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CleanGuruApp.Controllers
{
    public class AppointmentController : Controller
    {
        public ViewResult CreateAppointment()
        {
            return View();
        }
    }
}