using api.Model;
using API.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeRepository employeeRepository;
        public EmployeesController(EmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var result = employeeRepository.Get();
                if (result.Count() > 0)
                {
                    var response = new { Status = HttpStatusCode.OK, result, message = "Data ditemukan." };
                    return Ok(response);
                }
                else
                {
                    var response = new { Status = HttpStatusCode.NotFound, result, message = "Data tidak ditemukan." };
                    return NotFound(response);
                }
            }
            catch (Exception ex)
            {
                var response = new { statusCode = HttpStatusCode.InternalServerError, message = ex.Message };
                return StatusCode(500, response);
            }
        }
        [HttpGet("{NIK}")]
        public ActionResult Get(string NIK)
        {
            try
            {
                NIK = NIK.Trim();
                var result = employeeRepository.GetNIK(NIK);
                if (string.IsNullOrEmpty(NIK) || NIK.Contains(" "))
                {
                    var response = new { Status = HttpStatusCode.BadRequest, result, Message = "Input NIK tidak boleh kosong atau mengandung spasi atau whitespace apapun." };
                    return BadRequest(response);
                }
                else if (employeeRepository.GetNIK(NIK) == null)
                {
                    var response = new { Status = HttpStatusCode.NotFound, result, Message = "Data tidak ditemukan." };
                    return NotFound(response);
                }
                else
                {
                    var response = new { Status = 200, result, Message = "Data ditemukan." };
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { status = HttpStatusCode.InternalServerError, message = ex.Message });
            }  
        }
        //[HttpGet("{FirstName}")]
        //public ActionResult GetFName(string FirstName)
        //{
        //    return Ok(employeeRepository.GetFirstName(FirstName));
        //}
        [HttpPost]
        public ActionResult Post(Employee employee)
        {
            try
            {
                employeeRepository.Insert(employee);
                return this.Get(employee.NIK);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { status = HttpStatusCode.InternalServerError, message = ex.Message });
            }
        }
        [HttpPut]
        public ActionResult Put(Employee employee)
        {
            try
            {
                employeeRepository.Update(employee);
                return this.Get(employee.NIK);
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = HttpStatusCode.BadRequest, message = ex.Message });
            }  
        }
        [HttpDelete]
        public ActionResult DeleteAll(string NIK)
        {
            try
            {
                employeeRepository.DeleteAll();
                return Ok(new { Status = 200, result = employeeRepository.Get(), message = "Semua data terhapus" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = HttpStatusCode.BadRequest, message = ex.Message });
            }
        }
        [HttpDelete("{NIK}")]
        public ActionResult DeleteNIK(string NIK)
        {
            try {
                employeeRepository.Delete(NIK.Trim());
                return Ok(new {Status = 200, result = employeeRepository.Get(), message = "Data terhapus" });
            }
            catch (Exception)
            {
                var result = employeeRepository.GetNIK(NIK);
                return BadRequest(new { status = HttpStatusCode.BadRequest, result, message = "Data tidak ditemukan" });
            }
        }
    }
}
