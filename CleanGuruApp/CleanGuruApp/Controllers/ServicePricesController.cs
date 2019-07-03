using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CleanGuruApp.Models;
using CleanGuruApp.Models.DB;

namespace CleanGuruApp.Controllers
{
    public class ServicePricesController : Controller
    {
        private readonly ApplicationDBContext _context;

        public ServicePricesController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: ServicePrices
        public async Task<IActionResult> Index()
        {
            return View(await _context.ServicePrice.ToListAsync());
        }

        // GET: ServicePrices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servicePrice = await _context.ServicePrice
                .FirstOrDefaultAsync(m => m.IdServicePrice == id);
            if (servicePrice == null)
            {
                return NotFound();
            }

            return View(servicePrice);
        }

        // GET: ServicePrices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ServicePrices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdServicePrice,ServicePriceDescr,CtAmountHour,ClAmountHour,ServicePriceStatus")] ServicePrice servicePrice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(servicePrice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(servicePrice);
        }

        // GET: ServicePrices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servicePrice = await _context.ServicePrice.FindAsync(id);
            if (servicePrice == null)
            {
                return NotFound();
            }
            return View(servicePrice);
        }

        // POST: ServicePrices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdServicePrice,ServicePriceDescr,CtAmountHour,ClAmountHour,ServicePriceStatus")] ServicePrice servicePrice)
        {
            if (id != servicePrice.IdServicePrice)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(servicePrice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServicePriceExists(servicePrice.IdServicePrice))
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
            return View(servicePrice);
        }

        // GET: ServicePrices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servicePrice = await _context.ServicePrice
                .FirstOrDefaultAsync(m => m.IdServicePrice == id);
            if (servicePrice == null)
            {
                return NotFound();
            }

            return View(servicePrice);
        }

        // POST: ServicePrices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var servicePrice = await _context.ServicePrice.FindAsync(id);
            _context.ServicePrice.Remove(servicePrice);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServicePriceExists(int id)
        {
            return _context.ServicePrice.Any(e => e.IdServicePrice == id);
        }
    }
}
