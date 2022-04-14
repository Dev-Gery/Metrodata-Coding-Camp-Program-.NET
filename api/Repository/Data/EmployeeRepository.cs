using api.Context;
using api.Model;
using API.Model;
using API.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace API.Repository.Interface
{
    public class EmployeeRepository : GeneralRepository<MyContext, Employee, string>, IEmployeeRepository
    {
        private readonly MyContext myContext;
        private static List<string> AutoNIK = new List<string>() { };
        public EmployeeRepository(MyContext context) : base(context)
        {
            myContext = context;
        }
        public static void InitAutoNIK(MyContext context)
        {
            string autoNIKPattern = DateTime.Now.Year.ToString();
            string RegExPattern = $@"^{autoNIKPattern}";
            foreach (Employee eye in context.Employees.ToArray())
            {
                if (Regex.IsMatch(eye.NIK, RegExPattern))
                {
                    AutoNIK.Add(eye.NIK);
                }
                else
                {
                    continue;
                }
            }
            if (AutoNIK.Count() > 0)
            {
                AutoNIK.Sort();
            }
            else
            {
                AutoNIK.Add($"{autoNIKPattern}000");
            }
        }
        public static string GetNewAutoNIK(MyContext context)
        {
            if (AutoNIK.Count() == 0)
            {
                InitAutoNIK(context);
            }
            string lastNIK = AutoNIK.Last();
            int incrementDigitPlace = lastNIK.Length - 1;
            int increment = Int32.Parse(lastNIK.Substring(incrementDigitPlace)) + 1;
            string newNIK = lastNIK.Substring(0, incrementDigitPlace) + increment.ToString();
            AutoNIK.Add(newNIK);
            return newNIK;
        }
        public enum DataCheckConstants
        {
            NIKExists, NIKNotExists, NonNumericNIK, EmailExists, EmailNotExists, PhoneExists,
            EmailPhoneExist, ValidData, WrongOTP, InconsistentNewPassword, OTPIsUsed, OTPExpired
        }
        public static DataCheckConstants EyeDataCheck(MyContext context, Employee eye, string httpmethod = "post")
        {
            if (!string.IsNullOrWhiteSpace(eye.NIK))
            { 
                string fixNIK = Regex.Replace(eye.NIK, "\\s", "");
                if (Regex.IsMatch(fixNIK, "^[0-9]+$"))
                {
                    if (httpmethod == "post" && context.Employees.Find(fixNIK) != null)
                    {
                        return DataCheckConstants.NIKExists;
                    }
                    else
                    {
                        eye.NIK = fixNIK;
                    }
                }
                else
                {
                    return DataCheckConstants.NonNumericNIK;
                }
            }
            else
            {
                //GetNewAutoNIK() is postponed until all the data is valid
            }
            Boolean emailDuplicate = false, phoneDuplicate = false;
            var emp = context.Employees.SingleOrDefault(x => x.Email.ToLower() == eye.Email.ToLower() && x.NIK != eye.NIK);
            if (emp != null)
            {
                emailDuplicate = true;
            }
            emp = context.Employees.SingleOrDefault(x => x.Phone == eye.Phone && x.NIK != eye.NIK);
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
                if (string.IsNullOrWhiteSpace(eye.NIK))
                {
                    eye.NIK = GetNewAutoNIK(context);
                }  
                return DataCheckConstants.ValidData;
            }
        }
        public new DataCheckConstants Insert(Employee employee)
        {
            var dataCheck = EyeDataCheck(myContext, employee);
            if (dataCheck != DataCheckConstants.ValidData)
            {
                return dataCheck;
            }
            myContext.Employees.Add(employee);
            myContext.SaveChanges();
            return dataCheck;
        }

        public new DataCheckConstants Update(Employee employee)
        {
            var dataCheck = EyeDataCheck(myContext, employee, "put");
            if (dataCheck != DataCheckConstants.ValidData)
            {
                return dataCheck;
            }
            myContext.Entry(employee).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            myContext.SaveChanges();
            return dataCheck;
        }

        public override int Delete(string NIK)
        { 
            Employee emp = myContext.Employees.Find(NIK);
            myContext.Employees.Remove(emp);
            if (AutoNIK.Count() == 0)
            {
                InitAutoNIK(myContext);
            }
            AutoNIK.Remove(NIK);
            var result = myContext.SaveChanges();
            return result;
        }
    }
}
