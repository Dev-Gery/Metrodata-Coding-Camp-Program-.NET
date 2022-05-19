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

        public ActionResult<Employee> EmpDataCheck(string NIK, DataCheckConstants dataCheck)
        {
            if (dataCheck == DataCheckConstants.ValidData)
            {
                var result = employeeRepository.Get(NIK);
                return Ok(new { Status = 200, Result = result, Message = "Data berhasil dimasukkan" });
            }
            else if (dataCheck == DataCheckConstants.NonNumericNIK)
            {
                return BadRequest(new { Status = 400, Message = "NIK hanya boleh mengandung karakter numerik" });
            }
            else if (dataCheck == DataCheckConstants.NIKExists)
            {
                return BadRequest(new { Status = 400, Message = "NIK sudah ada" });
            }
            else if (dataCheck == DataCheckConstants.EmailExists)
            {
                return BadRequest(new { Status = 400, Message = "Email sudah ada" });
            }
            else if (dataCheck == DataCheckConstants.PhoneExists)
            {
                return BadRequest(new { Status = 400, Message = "Phone sudah ada" });
            }
            else
            {
                return BadRequest(new { Status = 400, Message = "Email dan Phone sudah ada" });
            }
        }

        public override ActionResult<Employee> Post(Employee employee)
        {
            try
            {
                DataCheckConstants dataCheck = employeeRepository.Insert(employee);
                return EmpDataCheck(employee.NIK, dataCheck);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { status = HttpStatusCode.InternalServerError, message = ex.Message });
            }
        }

        public override ActionResult<Employee> Put(Employee employee)
        {
            try
            {
                DataCheckConstants dataCheck = employeeRepository.Update(employee);
                return EmpDataCheck(employee.NIK, dataCheck);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { status = HttpStatusCode.InternalServerError, message = ex.Message });
            }
        }

    }
}
