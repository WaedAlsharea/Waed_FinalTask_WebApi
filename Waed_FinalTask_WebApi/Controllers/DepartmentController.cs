using learn.core.Data;
using learn.core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Waed_FinalTask_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {

        private readonly IDepartmentService DepartmentService;
        public DepartmentController(IDepartmentService DepartmentService)
        {
            this.DepartmentService = DepartmentService;

        }

        [HttpPost("CreateDept")]
        public IActionResult CreateDepartment([FromBody] DepartmentApi dept)
        {
            try
            {
                bool value = this.DepartmentService.createDept(dept);
                if (value)
                    return new JsonResult("Department Created");
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {

                return new JsonResult(ex.ToString());
            

            }
       }

  
        [HttpPut("UpdateDept/{id}")]
        public IActionResult UpdateDepartment([FromBody] DepartmentApi dept , int id)
        {
            try
            {
                bool value = this.DepartmentService.updateDept(dept, id);
                if (value)
                    return new JsonResult("Department Updated");
                else
                    return BadRequest("The Department Id deos not exist");
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.ToString());
            }
        }
        [HttpDelete("DeleteDept/{id}")]
        public IActionResult deleteDepartment(int id)
        {
            try
            {
                bool value = this.DepartmentService.deleteDept(id);
                if (value)
                    return new JsonResult("Department Deleted");
                else
                    return BadRequest("The Department Id deos not exist");

            }
            catch (Exception ex)
            {
                return new JsonResult(ex.ToString());
            }
        }
        [HttpGet("GetDepts")]
        public IActionResult getallDepartments()
        {
            try
            {
                IEnumerable<DepartmentApi> depts = this.DepartmentService.getallDepts();

                if (depts != null)
                    return Ok(depts);
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.ToString());
            }
            }





    }
}
