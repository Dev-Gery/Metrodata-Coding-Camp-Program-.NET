using Client.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;

        public AdminController(ILogger<AdminController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [Authorize(Roles = "Director, Manager")]
        public IActionResult Dashboard()
        {
            return View();
        }
        public new IActionResult Unauthorized()
        {
            return View();
        }
        public IActionResult Forbidden()
        {
            return View();
        }
        public IActionResult Notfound()
        {
            return View();
        }
    }
}
