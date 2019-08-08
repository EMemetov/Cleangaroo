//*********************************************************************************************************************
// Author: Satbyul Park and Mariia Staforkina - Last Modified Date: August, 7th 2019.
// The HomeController are been used to manage the views.
// 
//*********************************************************************************************************************
using Microsoft.AspNetCore.Mvc;

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
