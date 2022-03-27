using api.Context;
using api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace API.Repository.Interface
{
    public class EmployeeRepository : GeneralRepository<MyContext, Employee, string>, IEmployeeRepository
    {
        private readonly MyContext myContext;
        private static List<string> AutoNIK;
        public EmployeeRepository(MyContext context) : base(context)
        {
            myContext = context;
        }
        public static void InitAutoNIK(MyContext context)
        {
            string autoNIKPattern = DateTime.Now.Year.ToString();
            autoNIKPattern = $@"^{autoNIKPattern}";
            AutoNIK = new List<string> { $"{autoNIKPattern}000" };
            foreach (Employee eye in context.Employees.ToArray())
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
        public static string GetLastAutoNIK(MyContext context)
        {
            InitAutoNIK(context);
            string lastNIK = AutoNIK.Last();
            int increment = Int32.Parse(lastNIK.Substring(lastNIK.Length - 1)) + 1;
            return lastNIK.Substring(0, lastNIK.Length - 1) + increment.ToString();
        }
        public enum DataCheckConstants
        {
            NIKExists, NIKNotExists, NonNumericNIK, EmailExists, PhoneExists, EmailPhoneExist, ValidData
        }
        public static DataCheckConstants EyeDataCheck(MyContext context, Employee eye)
        {
            if (string.IsNullOrWhiteSpace(eye.NIK))
            {
                eye.NIK = GetLastAutoNIK(context);
            }
            else
            {
                string fixNIK = Regex.Replace(eye.NIK, "\\s", "");
                if (Regex.IsMatch(fixNIK, "^[0-9]+$"))
                {
                    if (context.Employees.Find(fixNIK) != null)
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

            Boolean emailDuplicate = false, phoneDuplicate = false;
            var emp = context.Employees.SingleOrDefault(x => x.Email.ToLower() == eye.Email.ToLower());
            if (emp != null)
            {
                emailDuplicate = true;
            }
            emp = context.Employees.SingleOrDefault(x => x.Phone == eye.Phone);
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
        public Employee GetFirstName(string FirstName)
        {
            return myContext.Employees.FirstOrDefault(x => x.FirstName == FirstName);
        }
    }
}
