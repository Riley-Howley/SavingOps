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
    public class FuelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FuelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Fuels
        public async Task<IActionResult> Index()
        {
              return View();
        }

        // GET: Fuels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Fuel == null)
            {
                return NotFound();
            }

            var fuel = await _context.Fuel
                .FirstOrDefaultAsync(m => m.FuelID == id);
            if (fuel == null)
            {
                return NotFound();
            }

            return View(fuel);
        }

        // GET: Fuels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fuels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FuelID,FuelSubmitted,Cost")] Fuel fuel)
        {
            if (ModelState.IsValid)
            {
                fuel.FuelSubmitted = DateTime.Now;
                _context.Add(fuel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fuel);
        }

        // GET: Fuels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Fuel == null)
            {
                return NotFound();
            }

            var fuel = await _context.Fuel.FindAsync(id);
            if (fuel == null)
            {
                return NotFound();
            }
            return View(fuel);
        }

        // POST: Fuels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FuelID,FuelSubmitted,Cost")] Fuel fuel)
        {
            if (id != fuel.FuelID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fuel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FuelExists(fuel.FuelID))
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
            return View(fuel);
        }

        // GET: Fuels/Delete/5
        public async Task<IActionResult> Delete()
        {
            var model = _context.Fuel;
            foreach (var i in model)
            {
                _context.Fuel.Remove(i);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Dashboard", "Home");
        }

        // POST: Fuels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed()
        {
            var model = _context.Fuel;
            foreach (var i in model)
            {
                _context.Fuel.Remove(i);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Dashboard", "Home");
        }

        private bool FuelExists(int id)
        {
          return _context.Fuel.Any(e => e.FuelID == id);
        }

        public IActionResult FuelListPartial()
        {
            return PartialView("_FuelList", _context.Fuel.ToList());
        }
    }
}
