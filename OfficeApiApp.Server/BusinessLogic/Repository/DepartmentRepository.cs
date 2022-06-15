using BusinessLogic.Interfaces;
using Data;
using Data.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Repository
{
    public class DepartmentRepository : IDepartmenRepositoty
    {
        private readonly OfficeDbContext _dbContext;

        public DepartmentRepository(OfficeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Department> GetDepartmentById(int id)
        {
            return await _dbContext.Departments.FirstOrDefaultAsync(dep => dep.DepartmentId == id);
        }

        public async Task<IEnumerable<Department>> GetAllDepartments()
        {
            return await _dbContext.Departments.ToListAsync();
        }
    }
}
