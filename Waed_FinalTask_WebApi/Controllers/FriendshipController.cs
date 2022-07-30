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
    public class FriendshipController : ControllerBase
    {
        private readonly IFriendshipService FriendshipService;
        public FriendshipController(IFriendshipService FriendshipService)
        {
            this.FriendshipService = FriendshipService;

        }


        [HttpPost("CreateFriendship")]
        public Task<bool> CreateFriendship([FromBody] FriendShipApi friendship)
        {
            try
            {
                return Task.FromResult(this.FriendshipService.createFriendship(friendship));
            }

            catch (Exception)
            {
                return Task.FromResult(false);
            }

        }

        [HttpDelete("DeleteFriendship/{id}")]
        public Task<bool> DeleteFriendship(int id)
        {
            try
            {

                return Task.FromResult(this.FriendshipService.deleteFriendship(id));

            }
            catch (Exception)
            {

                return Task.FromResult(false);
            }
        }
        [HttpGet("GetFriendships")]
        public IActionResult GetFriendships()
        {
            try
            {
                IEnumerable<FriendShipApi> friends = this.FriendshipService.getFriendship();

                if (friends != null)
                    return new JsonResult(friends);
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {

                return new JsonResult(ex.ToString());

            }

        }
        [HttpPut("BlockUser/{id}")]
        public  IActionResult Block([FromBody] FriendShipApi friend, int id)
        {
            try
            {
                bool done =  this.FriendshipService.BlockUser(friend, id);
                if (done)
                    return new JsonResult(true);
                else
                    return new JsonResult(false);
            }
            catch (Exception ex)
            {

                return new JsonResult(ex.ToString());

            }

        }




    } 

}
