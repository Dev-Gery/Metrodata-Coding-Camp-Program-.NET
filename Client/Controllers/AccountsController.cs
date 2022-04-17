using api.Model;
using API.Model;
using API.Model.ViewModel;
using API.Repository.ViewModel;
using BelajarCORS.Base;
using BelajarCORS.Repositories.Data;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using static API.Repository.Interface.EmployeeRepository;

namespace Client.Controllers
{
    [Route("/[controller]")]
    [Controller]
    public class AccountsController : BaseController<Account, AccountRepository, string>
    {
        private readonly AccountRepository repository;
        public AccountsController(AccountRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        [HttpGet("masterdata")]
        public async Task<JsonResult> GetMasterData()
        {
            var result = await repository.GetMasterData();
            return Json(result);
        }

        [HttpGet("masterdata/{NIK}")]
        public async Task<JsonResult> GetMasterData(string NIK)
        {
            var result = await repository.GetMasterData(NIK);
            return Json(result);
        }

        [HttpPost("register")]
        public JsonResult Register(RegisterVM registerVM)
        {
            var result = repository.Register(registerVM);
            return Json(result);
        }

    }
}