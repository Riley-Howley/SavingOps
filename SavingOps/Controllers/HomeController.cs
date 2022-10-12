﻿using Microsoft.AspNetCore.Mvc;
using SavingOps.Models;
using System.Diagnostics;

namespace SavingOps.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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

        public IActionResult Dashboard()
        {
            return View();  
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}