using learn.core.Data;
using learn.core.DTO;
using learn.core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Waed_FinalTask_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserMsgController : ControllerBase
    {
        private readonly IUserMsgService UserMsgService;
        public UserMsgController(IUserMsgService UserMsgService)
        {
            this.UserMsgService = UserMsgService;

        }


        [HttpPost("CreateUserMsg")]
        public IActionResult CreateUserMsg([FromBody] UserMsgApi umsg)
        {
            try
            {
                bool result = UserMsgService.createUserMsg(umsg);
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

        [HttpDelete("DeleteUserMsg")]
        public IActionResult DeleteUserMsg(int id)
        {
            try
            {

                bool result = UserMsgService.deleteUserMsg(id);
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
        [HttpGet("GetUserMsgs")]
        public IActionResult GetUserMsgs()
        {
            try
            {
                IEnumerable<UserMsgApi> msgs = this.UserMsgService.getUserMsgs();
                if (msgs != null)
                    return new JsonResult(msgs);
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }

        }
        [HttpGet("GetMsgsCount")]
        public IActionResult GetallUserMsgsCount()
        {
            try
            {
                int count = this.UserMsgService.GetallMsgsCount();

                string counts = "Messages Count: " + count;

                return new JsonResult(counts);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }


        }
        [HttpGet("MsgFilter")]
        public IActionResult MsgFilter([FromBody] string msg)
        {
            
            try
            {
                IEnumerable<UserMsgFilterDTO> msgess = this.UserMsgService.MsgFilter(msg);
                if (msgess != null)
                    return Ok(msgess);

                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }

        }
        [HttpGet("MsgDateFilter")]
        public IActionResult MsgFilter([FromBody] DateFilterDTO filter)
        {

            try
            {
                IEnumerable<UserMsgFilterDTO> msgess = this.UserMsgService.MsgFilter(filter);
                if (msgess.Count() > 0)
                    return Ok(msgess);

                else
                    return BadRequest("No Matched Data");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }

        }
        [HttpGet("MsgBackUp/{filename?}")]
        public IActionResult BackUp(string? filename)
        {
            //Do not send file name in the url if u want to see the JSON result only :)

            try
            {

                IEnumerable<MsgsBackUpDTO> msgess = this.UserMsgService.MsgBackUp();
                string FileName = @"C:\Users\C_ROAD\Downloads\"+filename+".txt";
                StreamWriter writer = new StreamWriter(FileName);
                List<string> backup = new List<string>();
                backup.Add("Sender\t\t\t\t\tMessage\t\t\t\t\tMessageDate\t\t\tReciver ");
                backup.Add("------------------------------------------------------------------------------------------------------------------------------------- ");

                foreach (var i in msgess.ToList())
                {
                    backup.Add(i.Sender.PadRight(40)  + i.Message.PadRight(40) +(i.MessageDate).ToString().PadRight(40) + i.Reciver);
                }
                foreach (var i in backup)
                {
                    writer.Write(i+ "\n\n");
                }
                writer.Close();
                if (msgess.Count() > 0)
                    return Ok(msgess);

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
