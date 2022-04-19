using API.Controllers.Base;
using API.Model;
using API.Model.ViewModel;
using API.Repository.Data;
using API.Repository.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using static API.Repository.Data.AccountRepository;
using static API.Repository.Interface.EmployeeRepository;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : BaseController<Account, AccountRepository, string>
    {
        private readonly AccountRepository accountRepository;
        
        public AccountsController(AccountRepository accountRepository, IConfiguration configuration) : base(accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        [Authorize(Roles = "Director, Manager")]
        [HttpGet("getmasterdata/{NIK}")]
        public ActionResult GetTheMasterData(string NIK)
        {
            try
            {
                var result = accountRepository.GetMasterEyeData(NIK);
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

        [Authorize(Roles = "Director, Manager")]
        [HttpGet("getmasterdata")]
        public ActionResult GetTheMasterData()
        {
            try
            {
                var result = accountRepository.GetMasterEyeData();
                if (result.Count() == 0)
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

        public override ActionResult<Account> Post(Account account)
        {
            try
            {
                DataCheckConstants data = accountRepository.Insert(account);
                if (data == DataCheckConstants.ValidData)
                {
                    return Ok(new { Status = 200, Message = $"Akun karyawan dengan NIK {account.NIK} berhasil dibuat" });
                }
                else if (data == DataCheckConstants.NIKNotExists)
                {
                    return BadRequest(new { Status = 400, Message = "Karyawan dengan NIK ini tidak ada" });
                }
                else if (data == DataCheckConstants.NIKExists)
                {
                    return BadRequest(new { Status = 400, Message = "Akun dengan NIK ini sudah ada" });
                }
                else
                {
                    return BadRequest(new { Status = 400, Message = "Input NIK tidak ada atau tidak valid" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { status = HttpStatusCode.InternalServerError, message = ex.Message });
            }
        }

        [HttpPost("register")]
        public ActionResult RegisterUp(RegisterVM register)
        {

            try
            {
                DataCheckConstants registration = accountRepository.Register(register);
                if (registration == DataCheckConstants.ValidData)
                {
                    var result = accountRepository.GetMasterEyeData(register.NIK);
                    return Ok(new { Status = 200, Result = result, Message = "Data berhasil dimasukkan" });
                }
                else if (registration == DataCheckConstants.NonNumericNIK)
                {
                    return BadRequest(new { Status = 400, Message = "NIK hanya boleh mengandung karakter numerik" });
                }
                else if (registration == DataCheckConstants.NIKExists)
                {
                    return BadRequest(new { Status = 400, Message = "NIK sudah ada" });
                }
                else if (registration == DataCheckConstants.EmailExists)
                {
                    return BadRequest(new { Status = 400, Message = "Email sudah ada" });
                }
                else if (registration == DataCheckConstants.PhoneExists)
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

        [HttpPost("login")]
        public ActionResult LoggingIn(LoginVM login)
        {
            try
            {
                var status = accountRepository.Login(login);
                if (status == AccountRepository.LoginCheckConstants.LoginSuccess)
                {
                    return Ok(new { Status = 200, login.JWT, Message = "Login berhasil" });
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
                var response = new { status = HttpStatusCode.InternalServerError, message = ex.Message };
                return StatusCode(500, response);
            }
        }

        [HttpPost("resetpassword")]
        public ActionResult ResetPaswword(ResetPasswordVM vm)
        {
            try
            {
                if (accountRepository.ResetPassword(vm.Email) == DataCheckConstants.EmailExists)
                {
                    return Ok(new { Status = 200, Message = "OTP sent" });
                }
                else
                {
                    return NotFound(new { Status = 404, Message = "Email not found in the database"});
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { statusCode = HttpStatusCode.InternalServerError, message = ex.Message });
            }
        }

        [HttpPost("changepassword")]
        public ActionResult ChangePassword(ChangePasswordVM changePasswordVM)
        {
            try
            {
                var result = accountRepository.ChangePassword(changePasswordVM);
                switch (result)
                {
                    case DataCheckConstants.ValidData:
                        return Ok(new { Status = 200, Message = $"The password of {changePasswordVM.Email} account has changed" });
                    case DataCheckConstants.EmailNotExists:
                        return NotFound(new { Status = 404, Message = $"Wrong email" });
                    case DataCheckConstants.WrongOTP:
                        return BadRequest(new { Status = 400, Message = "Wrong OTP" });
                    case DataCheckConstants.OTPExpired:
                        return BadRequest(new { Status = 400, Message = "Expired OTP" });
                    case DataCheckConstants.OTPIsUsed:
                        return BadRequest(new { Status = 400, Message = "OTP has been used for a password change once before" });
                    case DataCheckConstants.InconsistentNewPassword:
                        return BadRequest(new { Status = 400, Message = "The new password wasn't confirmed" });
                    default:
                        return null;
                }                
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { statusCode = HttpStatusCode.InternalServerError, message = ex.Message });
            }
        }
    }
}
