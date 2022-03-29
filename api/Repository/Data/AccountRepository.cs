using api.Context;
using api.Model;
using API.Model;
using API.Repository;
using API.Model.ViewModel;
using API.Repository.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using static API.Repository.Interface.EmployeeRepository;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace API.Repository.Data
{
    public class AccountRepository : GeneralRepository<MyContext, Account, string>
    {
        private readonly MyContext myContext;
        private Random randomInt = new Random();
        public AccountRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }
        public new DataCheckConstants Insert(Account account)
        {
            if (string.IsNullOrEmpty(account.NIK))
            {
                return DataCheckConstants.NonNumericNIK;
            }
            var emp = myContext.Employees.SingleOrDefault(x => x.NIK == account.NIK);
            if (emp == null)
            {
                return DataCheckConstants.NIKNotExists;
            }
            var acc = myContext.Accounts.SingleOrDefault(x => x.NIK == account.NIK);
            if (acc != null)
            {
                return DataCheckConstants.NIKExists;
            }
            account.Password = Hashing.GenerateHashPassword(account.Password);
            myContext.Accounts.Add(account);
            myContext.SaveChanges();
            return DataCheckConstants.ValidData;
        }
        public DataCheckConstants Register(RegisterVM registerVM)
        {
            var eye = new Employee
            {
                NIK = registerVM.NIK,
                FirstName = registerVM.FirstName,
                LastName = registerVM.LastName,
                Email = registerVM.Email,
                Phone = registerVM.Phone,
                BirthDate = registerVM.BirthDate,
                Salary = registerVM.Salary,
                Gender = registerVM.Gender
            };
            var dataCheck = EyeDataCheck(myContext, eye);
            if (dataCheck != DataCheckConstants.ValidData)
            {
                return dataCheck;
            };
            registerVM.NIK = eye.NIK;
            myContext.Employees.Add(eye);
            myContext.SaveChanges();

            var act = new Account
            {
                NIK = eye.NIK,
                Password = Hashing.GenerateHashPassword(registerVM.Password)
            };
            myContext.Accounts.Add(act);
            myContext.SaveChanges();

            var etn = new Education
            {
                Degree = registerVM.Degree,
                GPA = registerVM.GPA,
                University_Id = registerVM.University_Id
            };
            myContext.Educations.Add(etn);
            myContext.SaveChanges();

            var plg = new Profiling
            {
                NIK = eye.NIK,
                Education_Id = etn.Id
            };
            myContext.Profilings.Add(plg);
            myContext.SaveChanges();

            return DataCheckConstants.ValidData;
        }
        public MasterEyeDataVM GetMasterEyeData(string NIK)
        {
            Employee eye = myContext.Employees.Find(NIK);
            Profiling plg = myContext.Profilings.Find(eye.NIK);
            Education edu = myContext.Educations.Find(plg.Education_Id);
            University uty = myContext.Universities.Find(edu.University_Id);
            MasterEyeDataVM masterData = new MasterEyeDataVM
            {
                NIK = eye.NIK,
                FullName = eye.FirstName + " " + eye.LastName,
                BirthDate = eye.BirthDate,
                Email = eye.Email,
                Phone = eye.Phone,
                Salary = eye.Salary,
                Educations_Id = edu.Id,
                Degree = edu.Degree,
                University_Name = uty.Name,
                GPA = edu.GPA
            };
            if (eye.Gender == api.Model.Gender.Male)
            {
                masterData.Gender = "Male";
            }
            else
            {
                masterData.Gender = "Female";
            }
            return masterData;
        }
        public IEnumerable<MasterEyeDataVM> GetMasterEyeData()
        {
            List<MasterEyeDataVM> masterEyeDataVMs = new List<MasterEyeDataVM> { };
            foreach (Employee eye in myContext.Employees)
            {
                masterEyeDataVMs.Add(this.GetMasterEyeData(eye.NIK));
            }
            return masterEyeDataVMs;
        }
        public enum LoginCheckConstants
        {
            LoginSuccess, WrongEmail, WrongPassword, InexistentAccount
        }
        public LoginCheckConstants Login(LoginVM loginVM)
        {
            var eyes = myContext.Employees;
            var acts = myContext.Accounts;

            var eye = eyes.SingleOrDefault(emp => emp.Email.ToLower() == loginVM.Email.ToLower());
            if (eye == null)
            {
                return LoginCheckConstants.WrongEmail;
            }

            var act = acts.SingleOrDefault(acc => acc.NIK == eye.NIK);
            if (act == null)
            {
                return LoginCheckConstants.InexistentAccount;
            }

            bool PasswordMatch  = Hashing.ValidatePassword(loginVM.Password, act.Password);
            if (PasswordMatch)
            {
                return LoginCheckConstants.LoginSuccess;
            }
            else
            {
                return LoginCheckConstants.WrongPassword;
            }
        }
        public void GenerateOTP(Account account)
        {
            account.OTP = randomInt.Next(1000, 9999).ToString();
            account.IsUsed = false;
            DateTime currentDateTime = DateTime.Now;
            account.ExpiredToken = currentDateTime.AddMinutes(5);
            account.IsUsed = false;
            myContext.SaveChanges();
        }
        public DataCheckConstants ResetPassword(string recipientEmail)
        {
            Account account;
            try
            {
                var emp = myContext.Employees.SingleOrDefault(e => e.Email.ToLower() == recipientEmail.ToLower());
                if (emp == null)
                {
                    return DataCheckConstants.EmailNotExists;
                }
                else
                {
                    account = myContext.Accounts.Find(emp.NIK);
                    GenerateOTP(account);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            string to = recipientEmail; //To address    
            string from = ""; //From address    
            MailMessage message = new MailMessage(from, to);
            message.Subject = "Sending Email Using Asp.Net & C#";
            message.Body = $"This email is used to send OTP for resetting account password.\nHere is your OTP: {account.OTP}";
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
            NetworkCredential basicCredential1 = new
            NetworkCredential("gherysumual@gmail.com", "14mnumber49");
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;
            try
            {
                client.Send(message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return DataCheckConstants.EmailExists;              
        }
        public DataCheckConstants ChangePassword(ChangePasswordVM changePasswordVM)
        {
            try
            {
                var emp = myContext.Employees.SingleOrDefault(e => e.Email.ToLower() == changePasswordVM.Email.ToLower());
                if (emp == null)
                {
                    return DataCheckConstants.EmailNotExists;
                }
                else
                {
                    var account = myContext.Accounts.Find(emp.NIK);
                    if (account.OTP != changePasswordVM.OTP)
                    {
                        return DataCheckConstants.WrongOTP;
                    }
                    else if (DateTime.Now > account.ExpiredToken)
                    {
                        return DataCheckConstants.OTPExpired;
                    }
                    else if (account.IsUsed == true)
                    {
                        return DataCheckConstants.OTPIsUsed;
                    }
                    else if (changePasswordVM.NewPassword != changePasswordVM.ConfirmNewPassword)
                    {
                        return DataCheckConstants.InconsistentNewPassword;
                    }
                    else
                    {
                        account.Password = Hashing.GenerateHashPassword(changePasswordVM.NewPassword);
                        account.IsUsed = true;
                        myContext.SaveChanges();
                        return DataCheckConstants.ValidData;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }  
        }
    }
}
