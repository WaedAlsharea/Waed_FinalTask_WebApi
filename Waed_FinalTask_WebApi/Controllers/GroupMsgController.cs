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
    public class GroupMsgController : ControllerBase
    {
        private readonly IGroupMsgService GroupMsgService;
        public GroupMsgController(IGroupMsgService GroupMsgService)
        {
            this.GroupMsgService = GroupMsgService;

        }

        [HttpPost("CreateGroupMsg")]
        public IActionResult CreateGroup([FromBody] GroupMsgApi msg)
        {
            try
            {
                bool value = this.GroupMsgService.createGroupMsg(msg);
                if (value)
                    return new JsonResult("GroupMsg Created");
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {

                return new JsonResult(ex.ToString());


            }
        }


        [HttpDelete("DeleteGroupMsg/{id}")]

        public IActionResult DeleteGroup(int id)
        {
            try
            {
                bool value = this.GroupMsgService.deleteGroupMsg(id);
                if (value)
                    return new JsonResult("GroupMsg Deleted");
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {

                return new JsonResult(ex.ToString());


            }
        }
        [HttpGet("GetGroupMsgss")]
        public IActionResult GetGroups()
        {
            try
            {
                IEnumerable<GroupMsgApi> msgs = this.GroupMsgService.getGroupMsgs();

                if (msgs != null)
                    return new JsonResult(msgs);
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
