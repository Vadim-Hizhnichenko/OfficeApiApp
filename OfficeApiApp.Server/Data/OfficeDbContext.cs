using Data.Entity;
using Data.Enum;
using Microsoft.EntityFrameworkCore;
using System;

namespace Data
{
    public class OfficeDbContext : DbContext
    {
        public  OfficeDbContext(DbContextOptions<OfficeDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 1, DepartmentName = "Java" });
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 2, DepartmentName = ".Net" });
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 3, DepartmentName = "Python" });
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 4, DepartmentName = "QA" });
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 5, DepartmentName = "HR" });
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 6, DepartmentName = "Marketing" });


            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    EmployeeId = 1,
                    FirstName = "Alis",
                    LastName = "Roud",
                    Gender = Gender.Female,
                    DataOfBirthday = new DateTime(1994, 2, 5),
                    DepartmentId = 5

                });
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    EmployeeId = 2,
                    FirstName = "Jhon",
                    LastName = "Ready",
                    Gender = Gender.Male,
                    DataOfBirthday = new DateTime(1979, 1, 28),
                    DepartmentId = 1

                });
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    EmployeeId = 3,
                    FirstName = "Alex",
                    LastName = "Leus",
                    Gender = Gender.Male,
                    DataOfBirthday = new DateTime(1998, 10, 13),
                    DepartmentId = 1

                });
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    EmployeeId = 4,
                    FirstName = "Nikol",
                    LastName = "Zeus",
                    Gender = Gender.Female,
                    DataOfBirthday = new DateTime(1996, 12, 15),
                    DepartmentId = 2

                });
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    EmployeeId = 5,
                    FirstName = "Dima",
                    LastName = "Mykulenko",
                    Gender = Gender.Male,
                    DataOfBirthday = new DateTime(1994, 2, 5),
                    DepartmentId = 2

                });
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    EmployeeId = 6,
                    FirstName = "Sergey",
                    LastName = "Reva",
                    Gender = Gender.Male,
                    DataOfBirthday = new DateTime(1991, 1, 1),
                    DepartmentId = 3

                });
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    EmployeeId = 7,
                    FirstName = "Olena",
                    LastName = "Ivanova",
                    Gender = Gender.Female,
                    DataOfBirthday = new DateTime(1990, 12, 15),
                    DepartmentId = 4

                });
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    EmployeeId = 8,
                    FirstName = "Anastasiya",
                    LastName = "Reznik",
                    Gender = Gender.Female,
                    DataOfBirthday = new DateTime(1999, 5, 18),
                    DepartmentId = 5

                });


        }
    }
}
