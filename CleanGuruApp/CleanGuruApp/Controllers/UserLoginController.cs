using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanGuruApp.Models;
using CleanGuruApp.Models.DB;
using Microsoft.AspNetCore.Mvc;

namespace CleanGuruApp.Controllers
{
    public class UserLoginController : Controller
    {
        private IUserLoginRepository repository;

        public UserLoginController(IUserLoginRepository repo)
        {
            repository = repo;
        }

        //Show list of UserLogin
        public IActionResult List() => View(repository.UserLogins);                //OK

        //public IActionResult Add() => View("Edit", new UserLogin());

        [HttpGet]
        public IActionResult Edit(string userName) => View(repository.UserLogins.FirstOrDefault(c => c.UserName == userName));

        ////WORKING FOR TEST
        //[HttpPost]
        //public String Edit()                // = Edit in C229_GS2G3
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

        //Ailton
        [HttpPost]
        public IActionResult Edit(UserLogin userLogin)
        {
            //Console.WriteLine("Usuario: " + userLogin.UserName);      //Resolvido
            //Console.WriteLine("Usuario: " + userLogin.Role);
            //Console.WriteLine("Usuario: " + userLogin.Pin);
            if (ModelState.IsValid)
            {
                repository.SaveUserLogin(userLogin);
                TempData["message"] = $"User {userLogin.UserName} has been saved.";
                return RedirectToAction("List");
            }
            else
            {
                return View("../Home/Index");     //ALWAYS ????????  
            }
        }

        //public ViewResult Edit(UserLogin userLogin)
        //{
        //    repository.Add
        //}






    }
}