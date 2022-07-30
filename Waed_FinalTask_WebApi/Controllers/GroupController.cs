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
    public class GroupController : ControllerBase
    {
        private readonly IGroupService GroupService;
        public GroupController(IGroupService GroupService)
        {
            this.GroupService = GroupService;

        }

        [HttpPost("CreateGroup/{adminId}")]
        public IActionResult CreateGroup([FromBody] GroupApi group , int adminId )
        {
            try
            {
                bool value = this.GroupService.createGroup(group, adminId);
                if (value)
                    return new JsonResult("Group Created");
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {

                return new JsonResult(ex.ToString());


            }
        }


        [HttpDelete("DeleteGroup/{id}")]

        public IActionResult DeleteGroup(int id)
        {
            try
            {
                bool value = this.GroupService.deleteGroup(id);
                if (value)
                    return new JsonResult("Group Deleted");
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {

                return new JsonResult(ex.ToString());


            }
        }
        [HttpGet("GetGroups")]
        public IActionResult GetGroups()
        {
            try
            {
                IEnumerable<GroupApi> groups = this.GroupService.getGroups();

                if (groups != null)
                    return new JsonResult(groups);
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {

                return new JsonResult(ex.ToString());

            }

        }




    }
}
