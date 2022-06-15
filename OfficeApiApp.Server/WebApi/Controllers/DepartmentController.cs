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
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmenRepositoty _departmenRepositoty;

        public DepartmentController(IDepartmenRepositoty departmenRepositoty)
        {
            _departmenRepositoty = departmenRepositoty;
        }

        [HttpGet]
        public async Task<ActionResult> GetDepartment()
        {
            try
            {
                return Ok(await _departmenRepositoty.GetAllDepartments());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Department>> GetDepartmentById(int id)
        {
            try
            {
                var result = await _departmenRepositoty.GetDepartmentById(id);

                if(result == null)
                {
                    return NotFound("Not found department with this id");
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

    }
}
