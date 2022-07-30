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
    public class LikeController : ControllerBase
    {

        private readonly ILikeService LikeService;
        public LikeController(ILikeService LikeService)
        {
            this.LikeService = LikeService;

        }

        [HttpPost("CreateLike")]
        public IActionResult CreateLike([FromBody] LikeApi like)
        {
            try
            {
                bool value = this.LikeService.createLike(like);
                if (value)
                    return new JsonResult("Like Created");
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {

                return new JsonResult(ex.ToString());


            }
        }


        [HttpDelete("DeleteLike/{id}")]

        public IActionResult DeleteGroup(int id)
        {
            try
            {
                bool value = this.LikeService.deleteLike(id);
                if (value)
                    return new JsonResult("Like Deleted");
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {

                return new JsonResult(ex.ToString());


            }
        }
        [HttpGet("GetLikes")]
        public  IActionResult GetMyLikes()
        {
            try
            {
                IEnumerable<LikeApi> likes = this.LikeService.getMyLikes();

                if (likes != null)
                    return new JsonResult(likes);
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
