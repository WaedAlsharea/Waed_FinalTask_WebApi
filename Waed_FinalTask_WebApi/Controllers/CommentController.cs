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
    public class CommentController : ControllerBase
    {

        private readonly ICommentService commentservice;
        public CommentController(ICommentService commentservice)
        {
            this.commentservice = commentservice;

        }

        [HttpPost("CreateCategory")]
        public async Task<IActionResult> CreateComment([FromBody] CommentApi comment)
        {
            try
            {
                var done = Task.Run(() => commentservice.createComment(comment));
                await Task.WhenAll(done);

                if (done.Result)
                    return new JsonResult("Comment created");

                else
                    return BadRequest();
            }

            catch (Exception ex)
            {
                return new JsonResult(ex.Message.ToString());
            }

        }
        [HttpPut("UpdateComment/{id}")]
        public async Task<IActionResult> UpdateComment([FromBody] CommentApi comment, int id)
        {
            try
            {
                var done = Task.Run(() => commentservice.updateComment(comment,id));
                await Task.WhenAll(done);
                if (done.Result)
                    return new JsonResult("Comment Updated");

                else
                    return new JsonResult("The Comment Id deos not exist");
            }
            catch (Exception ex)
            {

                return new JsonResult(ex.Message.ToString());
            }
        }
        [HttpDelete("DeleteComment/{id}")]
        public Task<bool> DeleteComment(int id)
        {
            try
            {

                return Task.FromResult(this.commentservice.deleteComment(id));

            }
            catch (Exception)
            {

                return Task.FromResult(false);
            }
        }
        [HttpGet("GetComments")]
        public  IActionResult GetComments()
        {
            try
            {

                IEnumerable<CommentApi> comments = this.commentservice.getMyComments();

                if (comments != null)
                    return Ok(comments); 
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
