

using api.Model;
using BelajarCORS.Base;
using BelajarCORS.Repositories.Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace Client.Controllers
{
    [Route("/[controller]")]
    [Controller]
    public class EmployeesController : BaseController<Employee, EmployeeRepository, string>
    {
        private readonly EmployeeRepository repository;
        public EmployeesController(EmployeeRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        //[HttpGet]
        //public async Task<JsonResult> GetByNIK(string nik)
        //{
        //    var result = await repository.GetByNIK(nik);
        //    return Json(result);
        //}
    }
}

