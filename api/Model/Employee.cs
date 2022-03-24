using API.Model;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Model
{
    [Table("EMPLOYEE")]
    public class Employee
    {
        [Key] public string NIK { get; set; }
        [Required] public string FirstName { get; set; }
        [Required] public string LastName { get; set; }
        [Required] public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public int Salary { get; set; }
        public Gender Gender { get; set; }
        public Account Account { get; set; }
    }
    public enum Gender
    {
        Male,
        Female
    }
}


















