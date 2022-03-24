using api.Model;
using System;
using System.ComponentModel.DataAnnotations;

namespace API.Repository.ViewModel
{
    public class RegisterVM
    {
       public string NIK { get; set; }
       [Required] public string FirstName { get; set; }
       [Required] public string LastName { get; set; }
       [Required] public string Email { get; set; }
       [Required] public string Phone { get; set; }
       [Required] public DateTime BirthDate { get; set; }
       [Required] public int Salary { get; set; }
       [Required] public Gender Gender { get; set; }
       [Required] public string Password { get; set; }
        public string Degree { get; set; }
        public string GPA { get; set; }
        public int University_Id { get; set; }
    }
}
