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
    public class LoginController : Controller
    {
        private readonly LoginRepository repository;
        public LoginController(LoginRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        public JsonResult Authenticate(LoginVM login)
        {
            var results = repository.Ate(login);
            if (results.jwt != null)
            {
                HttpContext.Session.SetString("JWToken", results.jwt);
                //HttpContext.Session.SetString("Name", jwtHandler.GetName(token));
                //HttpContext.Session.SetString("ProfilePicture", "assets/img/theme/user.png");
            }
            return Json(results);
        }

    }
}
