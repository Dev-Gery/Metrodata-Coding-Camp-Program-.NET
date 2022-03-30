using System;
using System.Collections.Generic;

namespace API.Model.ViewModel
{
    public class MasterEyeDataVM
    {
        public string NIK { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public int Salary { get; set; }
        public int Educations_Id { get; set; }
        public string GPA { get; set; }
        public string Degree { get; set; }
        public string University_Name { get; set; }
        public List<int> Role_Ids { get; set; }
        public List<string> Role_Names { get; set; }
    }
}
