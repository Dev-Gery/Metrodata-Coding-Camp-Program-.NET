using API.Controllers.Base;
using API.Model;
using API.Model.ViewModel;
using API.Repository.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

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

        [Authorize]
        [HttpGet("TestJWT")]
        public ActionResult TestJWT()
        {
            return Ok("Test JWT berhasil");
        }

        [Authorize(Roles = "Director")]
        [HttpPost("AssignManager")]
        public ActionResult AssignManager(RoleAssigningVM RAGvm)
        {
            try
            {
                authorityRepository.AssignManager(RAGvm);
                return Ok(new { Status = 200, result = RAGvm, Message = $"Karyawan dengan NIK {RAGvm.NIK} sekarang telah menjadi manager" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { status = HttpStatusCode.InternalServerError, message = ex.Message });
            }
        }
        public override ActionResult<Authority> Post(Authority aty)
        {
            try
            {
                authorityRepository.Insert(aty);
                return Ok(new { Status = 200, Message = "Data berhasil dimasukkan" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { status = HttpStatusCode.InternalServerError, message = ex.Message });
            }
        }
    }
}
