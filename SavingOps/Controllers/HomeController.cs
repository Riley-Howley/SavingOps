using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SavingOps.Data;
using SavingOps.Models;
using System.Diagnostics;

namespace SavingOps.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated) {
                return RedirectToAction("Dashboard");
            } else
            {
                return View();
            }            
        }

        [Authorize]
        public async Task<IActionResult> Dashboard()
        {
            var model = new ListModel();
            model.AccountList = await _context.AccountSettings.ToListAsync();
            model.BillList = await _context.Bill.ToListAsync();
            model.FuelList = await _context.Fuel.ToListAsync();
            model.RentList = await _context.Rent.ToListAsync();
            model.SavingList = await _context.Saving.ToListAsync();
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}