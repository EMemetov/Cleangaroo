using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CleanGuruApp.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CleanGuruApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //MENU OPTIONS
        public IActionResult Service()
        {
            return View();
        }

        public ViewResult Register()
        {
            return View();
        }

        public ViewResult Login()
        {
            return View();
        }
        public ViewResult Schedule()
        {
            return View();
        }
        public ViewResult AboutUs()
        {
            return View();
        }
        public ViewResult Contact()
        {
            return View();
        }
        
        public ViewResult CreateAppointment()
        {
            return View();
        }

        public ViewResult CreateService()
        {
            return View();
        }

        //OTHERS
        public ViewResult CreateUser()
        {
            return View();
        }

        public ViewResult Manager()
        {
            return View();
        }
    }
}
