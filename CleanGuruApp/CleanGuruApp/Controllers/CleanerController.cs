//*********************************************************************************************************************
// Author: Theo Mitchel - Last Modified Date: August, 7th 2019.
// The CleanerController receives the cleaners data, validates the information and passes it to the data model.
// 
//*********************************************************************************************************************
using System.Linq;
using CleanGuruApp.Models;
using CleanGuruApp.Models.DB;
using Microsoft.AspNetCore.Mvc;

namespace CleanGuruApp.Controllers
{
    public class CleanerController : Controller
    {
        //declaring the repository variable to be used in the controller
        private readonly ICleanerRepository cleanerRepository;

        public CleanerController(ICleanerRepository repository)
        {
            cleanerRepository = repository;
        }

        //method to get and post the information about the cleaner
        //parameter "idCleaner" used to get the information about the cleaner
        [HttpGet]
        public IActionResult Register(int idCleaner) => View(cleanerRepository.Cleaners.FirstOrDefault(c => c.IdCleaner == idCleaner));

        [HttpPost]
        public IActionResult Register(Cleaner cleaner)
        {
            if (ModelState.IsValid)
            {
                cleanerRepository.SaveCleaner(cleaner);
                TempData["message"] = $"Cleaner {cleaner.UserName} has been successfully registered in the system";

                return View("../Home/Index");
            }
            else
            {
                return View(cleaner);
            }
        }

        //method to get the cleaners list
        public IActionResult ListOfCleaners()
        {
            var cleanerList = cleanerRepository.Cleaners;
            return View(cleanerList);
        }
    }
}