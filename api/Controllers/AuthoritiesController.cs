using API.Controllers.Base;
using API.Model;
using API.Repository.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthoritiesController : BaseController<Authority, AuthorityRepository, (string, int)>
    {
        private readonly AuthorityRepository authorityRepository;
        public AuthoritiesController(AuthorityRepository authorityRepository) : base(authorityRepository)
        {
            this.authorityRepository = authorityRepository;
        }
    }
}
