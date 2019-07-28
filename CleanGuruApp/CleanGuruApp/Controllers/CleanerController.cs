using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanGuruApp.Models;
using CleanGuruApp.Models.DB;
using Microsoft.AspNetCore.Mvc;

namespace CleanGuruApp.Controllers
{
    public class CleanerController : Controller
    {
        private readonly ICleanerRepository cleanerRepository;

        public CleanerController(ICleanerRepository repository)
        {
            cleanerRepository = repository;
        }

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

        public async Task<IActionResult> ListOfCleaners()
        {
            //return View(await cleanerRepository.Cleaners.ToListAsync());
            var cleanerList = cleanerRepository.Cleaners;
            return View(cleanerList);
            //return View();
        }
    }
}