using api.Context;
using api.Model;
using API.Model;
using API.Model.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API.Repository.Data
{
    public class AuthorityRepository : GeneralRepository<MyContext, Authority, (string, int)>
    {
        private readonly MyContext myContext;
        public AuthorityRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }

        public void AssignManager(RoleAssigningVM VM)
        {
            try
            {
                Employee eye = myContext.Employees.Find(VM.NIK);
                string eyeGender;
                if (eye.Gender == api.Model.Gender.Male)
                {
                    eyeGender = "Male";
                }
                else
                {
                    eyeGender = "Female";
                }

                string roleName = "Manager";
                Role rle = myContext.Roles.SingleOrDefault(r => r.Name.ToLower() == roleName.ToLower());

                var aty = new Authority
                {
                    Account_NIK = VM.NIK,
                    Role_Id = rle.Id
                };
                myContext.Authorities.Add(aty);
                myContext.SaveChanges();

                VM.First_Name = eye.FirstName;
                VM.Last_Name = eye.LastName;
                VM.Email = eye.Email;
                VM.Phone = eye.Phone;
                VM.Gender = eyeGender;
                VM.Role_Ids = "";
                VM.Role_Names = "";
                var roles = myContext.Roles.Where(r => r.Authorities.Any(a => a.Account_NIK == VM.NIK)).ToList<Role>();
                for (int i = 0; i < roles.Count; i++)
                {
                    if (i == roles.Count - 1)
                    {
                        VM.Role_Ids += roles[i].Id.ToString();
                        VM.Role_Names += roles[i].Name;
                    }
                    else
                    {
                        VM.Role_Ids += roles[i].Id.ToString() + ", ";
                        VM.Role_Names += roles[i].Name + ", ";
                    } 
                }

                //VM.Role_Ids = new List<int> { };
                //VM.Role_Names = new List<string> { };
                //foreach (var role in roles)
                //{
                //    VM.Role_Ids.Add(role.Id);
                //    VM.Role_Names.Add(role.Name);
                //}
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
