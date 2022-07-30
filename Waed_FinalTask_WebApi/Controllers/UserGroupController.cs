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
    public class UserGroupController : ControllerBase
    {
        private readonly IUserGroupService UserGroupService;
        public UserGroupController(IUserGroupService UserGroupService)
        {
            this.UserGroupService = UserGroupService;

        }



        [HttpPost("CreateUserGroup")]
        public IActionResult CreateUserGroup([FromBody] UserGroupApi usergroup)
        {
            try
            {
                bool result = UserGroupService.createUserGroup(usergroup);
                if (result)
                    return Ok(result);
                else
                    return BadRequest();
            }

            catch (Exception ex)
            {

                return BadRequest(ex.Message.ToString());
            }

        }

        [HttpDelete("DeleteUserGroup")]
        public IActionResult DeleteUserGroup(int id)
        {
            try
            {

                bool result = UserGroupService.deleteUserGroup(id);
                if (result)
                    return Ok(result);
                else
                    return BadRequest();
            }

            catch (Exception ex)
            {

                return BadRequest(ex.Message.ToString());
            }

        }
        [HttpGet("GetUsersInGroups")]
        public IActionResult GetUsers()
        {
            try
            {
                IEnumerable<UserGroupApi> users = this.UserGroupService.getUserGroups();
                if (users != null)
                    return new JsonResult(users);
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }

        }
        [HttpGet("GetMsgsCount")]
        public IActionResult GetGroupsMsgsCount()
        {
            try
            {
                int count = this.UserGroupService.getUserGroups().Count();

                return new JsonResult(count);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }

        }



    }
}
