using API.Controllers.Base;
using API.Model;
using API.Repository.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfilingsController : BaseController<Profiling, ProfilingRepository, string>
    {
        private readonly ProfilingRepository profilingRepository;
        public ProfilingsController(ProfilingRepository profilingRepository) : base(profilingRepository)
        {
            this.profilingRepository = profilingRepository;
        }
    }
}

