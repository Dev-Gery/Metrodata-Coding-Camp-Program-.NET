﻿using api.Context;
using api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace API.Repository.Interface
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly MyContext context;
        private static List<string> AutoNIK;
        public EmployeeRepository(MyContext context)
        {
            this.context = context;
            InitAutoNIK();
        } 
       
        public void InitAutoNIK()
        {
            string autoNIKPattern = DateTime.Now.ToString("yyyy") + "00";
            string x = $@"^{autoNIKPattern}";
            AutoNIK = new List<string> { $"{autoNIKPattern}0" };
            int i = 0;
            foreach (Employee eye in context.Employees)
            {
                if (Regex.IsMatch(eye.NIK, x))
                {
                    if (int.Parse(eye.NIK) > int.Parse(AutoNIK[i]))
                    {
                        AutoNIK.Add(eye.NIK);
                        i++;
                    }
                }     
            }
        } 
        public int Insert(Employee employee)
        { 
            if (string.IsNullOrWhiteSpace(employee.NIK))
            { 
                employee.NIK = (int.Parse(AutoNIK.Last()) + 1).ToString();
            }
            else if (Regex.IsMatch(Regex.Replace(employee.NIK, "\\s", ""), "[0-9]"))
            {
                employee.NIK = Regex.Replace(employee.NIK, "\\s", "");
            }
            else
            {
                throw new Exception("Input NIK hanya boleh mengandung karakter numerik");
            }
            DuplicateDataCheck(employee);
            context.Employees.Add(employee);
            var result = context.SaveChanges();
            return result;
        }
        private void DuplicateDataCheck (Employee eye)
        {
            Boolean emailDuplicate = false, phoneDuplicate = false;
            foreach (Employee emp in context.Employees)
            {
                if (eye.Email.Trim().ToLower() == emp.Email.Trim().ToLower())
                {
                    emailDuplicate = true; 
                }
                if (eye.Phone.Trim().ToLower() == emp.Phone.Trim().ToLower())
                {
                    phoneDuplicate = true;
                }
                if (emailDuplicate && phoneDuplicate)
                {
                    break;
                }
            }
            if (emailDuplicate && phoneDuplicate)
            {
                throw new Exception("Email input dan Phone input duplikat dengan yang sudah ada.");
            }
            else if (phoneDuplicate)
            {
                throw new Exception("Phone input duplikat dengan yang sudah ada.");
            }
            else if (emailDuplicate)
            {
                throw new Exception("Email input duplikat dengan yang sudah ada.");
            }
            else
            {
                return;
            }
        }
        public IEnumerable<Employee> Get()
        {
            return context.Employees.ToList();
        }
        public Employee GetNIK(string NIK)
        {
            return context.Employees.Find(NIK);
        }
        public Employee GetFirstName(string FirstName)
        {
            return context.Employees.FirstOrDefault(x => x.FirstName == FirstName);
        }
       
        public int Update(Employee employee)
        {
            context.Entry(employee).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            var result = context.SaveChanges();
            return result;
        }
        public int Delete(string NIK)
        {
            var entity = context.Employees.Find(NIK);
            context.Remove(entity);
            var result = context.SaveChanges();
            return result;
        }
        public int DeleteAll()
        {
            foreach (Employee emp in context.Employees)
            {
                context.Remove(emp);
            }
            return context.SaveChanges();
        }
    }
}