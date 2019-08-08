//*********************************************************************************************************************
// Author: Mariia Staforkina - Last Modified Date: August, 7th 2019.
// The UserLoginController receives the user login data, validates the information and passes it to the data model.
// 
//*********************************************************************************************************************
using System.Linq;
using CleanGuruApp.Models;
using CleanGuruApp.Models.DB;
using Microsoft.AspNetCore.Mvc;

namespace CleanGuruApp.Controllers
{
    public class UserLoginController : Controller
    {
        //declaring the repositories variables to be used in the assignCleanerController
        private IUserLoginRepository repository;

        public UserLoginController(IUserLoginRepository repo)
        {
            repository = repo;
        }

        //Show list of UserLogin
        public IActionResult List() => View(repository.UserLogins);

        [HttpGet]
        public IActionResult Edit(string userName) => View(repository.UserLogins.FirstOrDefault(c => c.UserName == userName));

        [HttpPost]
        public IActionResult Edit(UserLogin userLogin)
        {
            if (ModelState.IsValid)
            {
                repository.SaveUserLogin(userLogin);
                TempData["message"] = $"User {userLogin.UserName} has been saved.";
                return RedirectToAction("List");
            }
            else
            {
                return View("../Home/Index");
            }
        }
    }
}