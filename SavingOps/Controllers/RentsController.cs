using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SavingOps.Data;
using SavingOps.Models;

namespace SavingOps.Controllers
{
    [Authorize]
    public class RentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Rents
        public async Task<IActionResult> Index()
        {
              return View();
        }

        // GET: Rents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Rent == null)
            {
                return NotFound();
            }

            var rent = await _context.Rent
                .FirstOrDefaultAsync(m => m.RentID == id);
            if (rent == null)
            {
                return NotFound();
            }

            return View(rent);
        }

        // GET: Rents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RentID,DateSubmitted,Cost")] Rent rent)
        {
            if (ModelState.IsValid)
            {
                rent.DateSubmitted = DateTime.Now;
                rent.Cost = _context.AccountSettings.First().RentPrice;
                _context.Add(rent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rent);
        }

        // GET: Rents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Rent == null)
            {
                return NotFound();
            }

            var rent = await _context.Rent.FindAsync(id);
            if (rent == null)
            {
                return NotFound();
            }
            return View(rent);
        }

        // POST: Rents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RentID,DateSubmitted,Cost")] Rent rent)
        {
            if (id != rent.RentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentExists(rent.RentID))
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
            return View(rent);
        }

        // GET: Rents/Delete/5
        public async Task<IActionResult> Delete()
        {
            var model = _context.Rent;
            foreach (var i in model)
            {
                _context.Rent.Remove(i);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Dashboard", "Home");
        }

        // POST: Rents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed()
        {
            var model = _context.Rent;
            foreach (var i in model)
            {
                _context.Rent.Remove(i);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Dashboard", "Home");
        }

        private bool RentExists(int id)
        {
          return _context.Rent.Any(e => e.RentID == id);
        }
        public IActionResult RentListPartial()
        {
            return PartialView("_RentList", _context.Rent.ToList());
        }
    }
}
