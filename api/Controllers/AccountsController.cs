using API.Controllers.Base;
using API.Model;
using API.Model.ViewModel;
using API.Repository.Data;
using API.Repository.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using static API.Repository.Data.AccountRepository;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : BaseController<Account, AccountRepository, string>
    {
        private readonly AccountRepository accountRepository;
        public AccountsController(AccountRepository accountRepository) : base(accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        [HttpPost("register")]
        public ActionResult RegisterUp(RegisterVM register)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(register.NIK))
                {
                    register.NIK = accountRepository.GetLastAutoNIK();
                }
                DataCheckConstants registration = accountRepository.Register(register);
                Object response;
                if (registration == DataCheckConstants.ValidData)
                {
                    var result = accountRepository.GetMasterData(register.NIK);
                    response = new { Status = 200, Result = result,  Message = "Data berhasil dimasukkan" };
                }
                else if (registration == DataCheckConstants.EmailExists)
                {
                    response = new { Status = 400, Message = "Email sudah ada" };
                }
                else if (registration == DataCheckConstants.PhoneExists)
                {
                    response = new { Status = 400, Message = "Phone sudah ada" };
                }
                else
                {
                    response = new { Status = 400, Message = "Email dan Phone sudah ada" };
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { status = HttpStatusCode.InternalServerError, message = ex.Message });
            }
        }

        [HttpPost("login")]
        public ActionResult LoggingIn(LoginVM login)
        {
            try
            {
                var status = accountRepository.Login(login);
                if (status == AccountRepository.LoginCheckConstants.LoginSuccess)
                {
                    return Ok(new { Status = 200, Message = "Login berhasil" });
                }
                else if (status == AccountRepository.LoginCheckConstants.WrongEmail)
                {
                    return BadRequest(new { status = 400, Message = "Email salah" });
                }
                else if (status == AccountRepository.LoginCheckConstants.WrongPassword)
                {
                    return BadRequest(new { status = 400, Message = "Password salah" });
                }
                else
                {
                    return NotFound(new { status = 404, Message = "Akun tidak ada" });
                }
            }
            catch (Exception ex)
            {
                var response = new { statusCode = HttpStatusCode.InternalServerError, message = ex.Message };
                return StatusCode(500, response);
            }
        }

        [HttpGet("getmasterdata/{NIK}")]
        public ActionResult GetTheMasterData(string NIK)
        {
            try
            {
                var result = accountRepository.GetMasterData(NIK);
                if (result == null)
                {
                    return NotFound(new { Status = 404, Result = result, Message = "Data tidak ditemukan" });
                }
                else
                {
                    return Ok(new { Status = 200, Result = result, Message = "Data ditemukan" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { statusCode = HttpStatusCode.InternalServerError, message = ex.Message });
            }
        }

        [HttpGet("getmasterdata")]
        public ActionResult GetTheMasterData()
        {
            try
            {
                var result = accountRepository.GetMasterData();
                if (result == null)
                {
                    return NotFound(new { Status = 404, Result = result, Message = "Data tidak ditemukan" });
                }
                else
                {
                    return Ok(new { Status = 200, Result = result, Message = "Beberapa data ditemukan" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { statusCode = HttpStatusCode.InternalServerError, message = ex.Message });
            }
        }
    }
}
