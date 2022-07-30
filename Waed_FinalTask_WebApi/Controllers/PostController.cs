using learn.core.Data;
using learn.core.DTO;
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
    public class PostController : ControllerBase
    {



        private readonly IPostService PostService;
        public PostController(IPostService PostService)
        {
            this.PostService = PostService;

        }



        [HttpPost("CreatePost")]
        public IActionResult CreatePost([FromBody] PostApi post)
        {
            try
            {

                bool result = PostService.createPost(post);
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

        [HttpDelete("DeletePost")]
        public IActionResult DeletePost(int id)
        {
            try
            {

                bool result = PostService.deletePost(id);
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
        [HttpGet("GetPosts")]
        public IActionResult GetPosts( )
        {
            try
            {

                IEnumerable<PostApi> posts = this.PostService.getMyPosts();

                if (posts != null)
                    return new JsonResult(posts);
                else
                    return BadRequest();
            }

            catch (Exception ex)
            {

                return BadRequest(ex.Message.ToString());
            }

        }


        [HttpGet("PostLikesCount")]
        public IActionResult LikesCount()
        {
            try
            {
                IEnumerable<PostLikeCountDTO> msgsCount = PostService.LikesCount();
                if (msgsCount != null)
                    return Ok(msgsCount);

                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }

        }











    }
}
