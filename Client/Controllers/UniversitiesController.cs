

using api.Model;
using API.Model;
using BelajarCORS.Base;
using BelajarCORS.Repositories.Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Client.Controllers
{
    public class UniversitiesController : BaseController<University, UniversityRepository, int>
    {
        private readonly UniversityRepository repository;
        public UniversitiesController(UniversityRepository repository) : base(repository)
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

