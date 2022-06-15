using Data.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Entity
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(15)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(15)]
        public string LastName { get; set; }

        public DateTime DataOfBirthday { get; set; }
        public Gender Gender { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }


    }
}
