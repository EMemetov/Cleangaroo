﻿//*********************************************************************************************************************
// Author: Satbyul Park - Last Modified Date: August, 7th 2019.
// The ScheduleCleanersController receives the schedule cleaners data, validates the information and passes it to the data model.
// 
//*********************************************************************************************************************

using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CleanGuruApp.Models;
using CleanGuruApp.Models.DB;

namespace CleanGuruApp.Controllers
{
    public class ScheduleCleanersController : Controller
    {
        //declaring the repositories variables to be used in the assignCleanerController
        private readonly ApplicationDBContext _context;

        public ScheduleCleanersController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: ScheduleCleaners
        public async Task<IActionResult> Index()
        {
            return View(await _context.ScheduleCleaner.ToListAsync());
        }

        // GET: ScheduleCleaners/Details/5
        //parameter "id" used to get the information about the cleaner schedule
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scheduleCleaner = await _context.ScheduleCleaner
                .FirstOrDefaultAsync(m => m.IdScheduleCleaner == id);
            if (scheduleCleaner == null)
            {
                return NotFound();
            }

            return View(scheduleCleaner);
        }

        // GET: ScheduleCleaners/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ScheduleCleaners/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdScheduleCleaner,DayWeek,InitialTime,FinishTime,IdCleaner")] ScheduleCleaner scheduleCleaner)
        {
            if (ModelState.IsValid)
            {
                _context.Add(scheduleCleaner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(scheduleCleaner);
        }

        // GET: ScheduleCleaners/Edit/5
        //parameter "id" used to edit the information about the cleaner schedule
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scheduleCleaner = await _context.ScheduleCleaner.FindAsync(id);
            if (scheduleCleaner == null)
            {
                return NotFound();
            }
            return View(scheduleCleaner);
        }

        // POST: ScheduleCleaners/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdScheduleCleaner,DayWeek,InitialTime,FinishTime,IdCleaner")] ScheduleCleaner scheduleCleaner)
        {
            if (id != scheduleCleaner.IdScheduleCleaner)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(scheduleCleaner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScheduleCleanerExists(scheduleCleaner.IdScheduleCleaner))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(scheduleCleaner);
        }

        // GET: ScheduleCleaners/Delete/5
        //parameter "id" used to delete the information about the cleaner schedule
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scheduleCleaner = await _context.ScheduleCleaner
                .FirstOrDefaultAsync(m => m.IdScheduleCleaner == id);
            if (scheduleCleaner == null)
            {
                return NotFound();
            }

            return View(scheduleCleaner);
        }

        // POST: ScheduleCleaners/Delete/5
        //parameter "id" used to delete the information about the cleaner schedule
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var scheduleCleaner = await _context.ScheduleCleaner.FindAsync(id);
            _context.ScheduleCleaner.Remove(scheduleCleaner);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        //method to verify if the schedule exists
        //parameter "id" used to verify if the schedule of the cleanear exists
        private bool ScheduleCleanerExists(int id)
        {
            return _context.ScheduleCleaner.Any(e => e.IdScheduleCleaner == id);
        }
    }
}
