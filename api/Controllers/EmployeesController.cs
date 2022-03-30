using api.Context;
using api.Model;
using API.Controllers.Base;
using API.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Net;
using System.Text.RegularExpressions;
using static API.Repository.Interface.EmployeeRepository;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : BaseController<Employee, EmployeeRepository, string>
    {
        private readonly EmployeeRepository employeeRepository;
        
        public EmployeesController(EmployeeRepository employeeRepository) : base(employeeRepository)
        {
            this.employeeRepository = employeeRepository;
            
        }

        [HttpGet("TestCORS")]
        public ActionResult TestCORS()
        {
            return Ok("Test CORS berhasil");
        }

        [HttpPost("employee")]
        public new ActionResult Post(Employee employee)
        {
            try
            {
                DataCheckConstants data = employeeRepository.Insert(employee);
                if (data == DataCheckConstants.ValidData)
                {
                    var result = employeeRepository.Get(employee.NIK);
                    return Ok(new { Status = 200, Result = result, Message = "Data berhasil dimasukkan" });
                }
                else if (data == DataCheckConstants.NonNumericNIK)
                {
                    return BadRequest(new { Status = 400, Message = "NIK hanya boleh mengandung karakter numerik" });
                }
                else if (data == DataCheckConstants.NIKExists)
                {
                    return BadRequest(new { Status = 400, Message = "NIK sudah ada" });
                }
                else if (data == DataCheckConstants.EmailExists)
                {
                    return BadRequest(new { Status = 400, Message = "Email sudah ada" });
                }
                else if (data == DataCheckConstants.PhoneExists)
                {
                    return BadRequest(new { Status = 400, Message = "Phone sudah ada" });
                }
                else
                {
                    return BadRequest(new { Status = 400, Message = "Email dan Phone sudah ada" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { status = HttpStatusCode.InternalServerError, message = ex.Message });
            }
        }
    }
}
