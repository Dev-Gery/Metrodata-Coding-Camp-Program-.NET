using api.Context;
using api.Model;
using API.Model;
using API.Model.ViewModel;
using API.Repository.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace API.Repository.Data
{
    public class AccountRepository : GeneralRepository<MyContext, Account, string>
    {
        private readonly MyContext myContext;
        private static List<string> AutoNIK;
        public AccountRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
            InitAutoNIK();
        }
        public void InitAutoNIK()
        {
            string autoNIKPattern = DateTime.Now.Year.ToString();
            autoNIKPattern = $@"^{autoNIKPattern}";
            AutoNIK = new List<string> { $"{autoNIKPattern}000" };
            foreach (Employee eye in myContext.Employees.ToArray())
            {
                if (Regex.IsMatch(eye.NIK, autoNIKPattern))
                {
                    AutoNIK.Add(eye.NIK);
                }
                else
                {
                    continue;
                }
            }
            AutoNIK.Sort();
        }
        public string GetLastAutoNIK()
        {
            string lastNIK = AutoNIK.Last();
            int increment = Int32.Parse(lastNIK.Substring(lastNIK.Length - 1)) + 1;
            return lastNIK.Substring(0, lastNIK.Length - 1) + increment.ToString();
        }
        public enum DataCheckConstants
        {
            EmailExists, PhoneExists, EmailPhoneExist, ValidData
        }
        private DataCheckConstants DuplicateDataCheck(Employee eye)
        {
            Boolean emailDuplicate = false, phoneDuplicate = false;
            var emp = myContext.Employees.SingleOrDefault(x => x.Email.ToLower() == eye.Email.ToLower());
            if (emp != null)
            {
                emailDuplicate = true;
            }

            emp = myContext.Employees.SingleOrDefault(x => x.Phone == eye.Phone);
            if (emp != null)
            {
                phoneDuplicate = true;
            }

            if (emailDuplicate && phoneDuplicate)
            {
                return DataCheckConstants.EmailPhoneExist;
            }
            else if (phoneDuplicate)
            {
                return DataCheckConstants.PhoneExists;
            }
            else if (emailDuplicate)
            {
                return DataCheckConstants.EmailExists;
            }
            else
            {
                return DataCheckConstants.ValidData;
            }
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
            var duplicateCheck = DuplicateDataCheck(eye);
            if (duplicateCheck != DataCheckConstants.ValidData)
            {
                return duplicateCheck;
            };
            myContext.Employees.Add(eye);
            myContext.SaveChanges();

            var act = new Account
            {
                NIK = eye.NIK,
                Password = registerVM.Password
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

            if (act.Password == loginVM.Password)
            {
                return LoginCheckConstants.LoginSuccess;
            }
            else
            {
                return LoginCheckConstants.WrongPassword;
            }
        }
        public MasterEyeDataVM GetMasterData(string NIK)
        {
            Employee eye = myContext.Employees.Find(NIK);
            Profiling plg = myContext.Profilings.Find(NIK);
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
        public IEnumerable<MasterEyeDataVM> GetMasterData()
        {
            List<MasterEyeDataVM> masterEyeDataVMs = new List<MasterEyeDataVM> { };
            foreach (Employee eye in myContext.Employees)
            {
                masterEyeDataVMs.Add(this.GetMasterData(eye.NIK));
            }
            return masterEyeDataVMs;
        }
    }
}
