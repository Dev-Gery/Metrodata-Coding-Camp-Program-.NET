using API.Model.ViewModel;
using BelajarCORS.Base;
using BelajarCORS.Repositories.Data;
using Client.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Controllers
{
    public class LoginsController : Controller
    {
        private readonly ILogger<LoginsController> _logger;
        private readonly LoginRepository repository;
        public LoginsController(ILogger<LoginsController> logger, LoginRepository repository)
        {
            _logger = logger;
            this.repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Authenticate(LoginVM login)
        {
            var results = repository.Ate(login);
            HttpContext.Session.SetString("JWToken", results.jwt);
            //HttpContext.Session.SetString("Name", jwtHandler.GetName(token));
            //HttpContext.Session.SetString("ProfilePicture", "assets/img/theme/user.png");
            return Json(results);
        }

    }
}
