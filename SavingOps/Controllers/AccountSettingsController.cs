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
    public class AccountSettingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountSettingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AccountSettings
        public async Task<IActionResult> Index()
        {
              return View(await _context.AccountSettings.ToListAsync());
        }

        // GET: AccountSettings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AccountSettings == null)
            {
                return NotFound();
            }

            var accountSettings = await _context.AccountSettings
                .FirstOrDefaultAsync(m => m.AccountSettingsID == id);
            if (accountSettings == null)
            {
                return NotFound();
            }

            return View(accountSettings);
        }

        // GET: AccountSettings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AccountSettings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AccountSettingsID,RentPrice,SavingsGoal")] AccountSettings accountSettings)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accountSettings);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(accountSettings);
        }

        // GET: AccountSettings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AccountSettings == null)
            {
                return NotFound();
            }

            var accountSettings = await _context.AccountSettings.FindAsync(id);
            if (accountSettings == null)
            {
                return NotFound();
            }
            return RedirectToAction("Dashboard", "Home");
        }

        // POST: AccountSettings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AccountSettingsID,RentPrice,SavingsGoal")] AccountSettings accountSettings)
        {
            id = accountSettings.AccountSettingsID;
            if (id != accountSettings.AccountSettingsID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accountSettings);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountSettingsExists(accountSettings.AccountSettingsID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Dashboard", "Home");
            }
            return RedirectToAction("Dashboard", "Home");
        }

        // GET: AccountSettings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AccountSettings == null)
            {
                return NotFound();
            }

            var accountSettings = await _context.AccountSettings
                .FirstOrDefaultAsync(m => m.AccountSettingsID == id);
            if (accountSettings == null)
            {
                return NotFound();
            }

            return View(accountSettings);
        }

        // POST: AccountSettings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AccountSettings == null)
            {
                return Problem("Entity set 'ApplicationDbContext.AccountSettings'  is null.");
            }
            var accountSettings = await _context.AccountSettings.FindAsync(id);
            if (accountSettings != null)
            {
                _context.AccountSettings.Remove(accountSettings);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccountSettingsExists(int id)
        {
          return _context.AccountSettings.Any(e => e.AccountSettingsID == id);
        }
        public IActionResult AccountPartial()
        {
            return PartialView("_AccountSettings", _context.AccountSettings.First());
        }
        public IActionResult AddAccountPartial()
        {
            return PartialView("_AddAccountSettings");
        }
    }
}
