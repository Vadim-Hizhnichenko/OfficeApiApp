using BusinessLogic.Interfaces;
using Data.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmloyeeRepository _employeeRepository;

        public EmployeesController(IEmloyeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllEmployees()
        {
            try
            {
                return Ok(await _employeeRepository.GetAllEmployees());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Employee>> GetAllEmployeeById(int id)
        {
            try
            {
                var result = await _employeeRepository.GetEmployeeById(id);

                if(result == null)
                {
                    return NotFound("Not fount employee with this id");
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        [HttpGet("{searchByName}")]
        public async Task<ActionResult<IEnumerable<Employee>>> SearchByName(string name)
        {
            try
            {
                var result = await _employeeRepository.SearchEmployee(name);
                if (result.Any())
                {
                    return Ok(result);
                }

                return NotFound("Not found employee with this name");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
        {
            try
            {
                if(employee == null)
                {
                    return BadRequest("Employee data is null");
                }

                var result = await _employeeRepository.AddEmployee(employee);
                return CreatedAtAction(nameof(GetAllEmployeeById),
                    new { id = employee.EmployeeId }, result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Employee>> UpdateEmployee(Employee employee, int id)
        {
            try
            {
                if (id != employee.EmployeeId)
                {
                    return BadRequest("Employee id is mismatch");
                }

                var employeeForUpdate = await _employeeRepository.GetEmployeeById(id);

                if(employeeForUpdate == null)
                {
                    return NotFound("Employe not found with this id");
                }

                return await _employeeRepository.UpdateEmployee(employee);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteEmployeeById(int id)
        {
            try
            {
                var employeeForDelete = await _employeeRepository.GetEmployeeById(id);

                if(employeeForDelete == null)
                {
                    return NotFound("Employe not found with this id");
                }

                await _employeeRepository.DeleteEmployeeById(id);

                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

    }
}
