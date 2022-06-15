using BusinessLogic.Interfaces;
using Data;
using Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Repository
{
    public class EmployeeRepository : IEmloyeeRepository
    {
        private readonly OfficeDbContext _dbContext;
        public EmployeeRepository(OfficeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Employee> AddEmployee(Employee employee)
        {
            if(employee.Department != null)
            {
                _dbContext.Entry(employee.Department).State = EntityState.Unchanged;
            }

            var result = await _dbContext.Employees.AddAsync(employee);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteEmployeeById(int id)
        {
            var result = await _dbContext.Employees.FirstOrDefaultAsync(emp => emp.EmployeeId == id);
            if(result != null)
            {
                _dbContext.Employees.Remove(result);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return await _dbContext.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _dbContext.Employees
                .Include(emp => emp.Department)
                .FirstOrDefaultAsync(emp => emp.EmployeeId == id); 
        }

        public async Task<IEnumerable<Employee>> SearchEmployee(string name)
        {
            IQueryable<Employee> query = _dbContext.Employees;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(emp => emp.FirstName.Contains(name) || emp.LastName.Contains(name));
            }

            return await query.ToListAsync();
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var result = await _dbContext.Employees.FirstOrDefaultAsync(emp => emp.EmployeeId == employee.EmployeeId);

            if(result != null)
            {
                result.FirstName = employee.FirstName;
                result.LastName = employee.LastName;
                result.DataOfBirthday = employee.DataOfBirthday;
                result.Gender = employee.Gender;
                
                if(employee.DepartmentId != 0)
                {
                    result.DepartmentId = employee.DepartmentId;
                }
                

                await _dbContext.SaveChangesAsync();
                return result;
            }

            return null;
        }
    }
}
