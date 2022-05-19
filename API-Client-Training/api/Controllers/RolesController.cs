using API.Controllers.Base;
using API.Model;
using API.Repository.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : BaseController<Role, RoleRepository, int>
    {
        private readonly RoleRepository roleRepository;
        public RolesController(RoleRepository roleRepository) : base(roleRepository)
        {
            this.roleRepository = roleRepository;
        }
     }
}

