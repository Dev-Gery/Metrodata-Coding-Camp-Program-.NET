using API.Controllers.Base;
using API.Model;
using API.Repository.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationsController : BaseController<Education, EducationRepository, int>
    {
        public EducationsController(EducationRepository educationRepository) : base(educationRepository)
        {

        }
    }
}
