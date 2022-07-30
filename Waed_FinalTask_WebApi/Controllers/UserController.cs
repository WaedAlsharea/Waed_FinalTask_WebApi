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
    public class UserController : ControllerBase
    {
        private readonly IUserService UserService;
        public UserController(IUserService UserService)
        {
            this.UserService = UserService;

        }



        [HttpPost("CreateUser")]
        public IActionResult CreateUser([FromBody] UserApi user)
        {
            try
            {
                bool result = UserService.createUser(user);
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

        [HttpDelete("DeleteUser")]
        public IActionResult DeleteUser(int id)
        {
            try
            {

                bool result = UserService.deleteUser(id);
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
        [HttpGet("GetUsers")]
        public IActionResult GetUsers()
        {
            try
            {
                IEnumerable<UserApi> users = this.UserService.getallUsers();
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


        [HttpDelete("UpdateUser")]
        public IActionResult UpdateUser([FromBody] UserApi user, int id)
        {
            try
            {
                bool result = UserService.updateUser(user, id);
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
        [HttpGet("UserMsgsCount")]
        public IActionResult UserMsgsCount()
        {
            try
            {
                IEnumerable<UserMsgsDTO> msgsCount = UserService.MsgsCount();
                if (msgsCount!=null)
                    return Ok(msgsCount);

                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }

        }
        [HttpGet("UserVisaCount")]
        public IActionResult UserVisaCount()
        {
            try
            {
                IEnumerable<UserVisaCountDTO> msgsCount = UserService.VisaCount();
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
        [HttpGet("UsersCityCount")]
        public IActionResult UsersCityCount()
        {
            try
            {
                IEnumerable<UsersCityCountDTO> msgsCount = UserService.CityCount();
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
        [HttpPost("Login")]
        public IActionResult Authentication([FromBody] UserApi login)
        {
            var RESULT = UserService.Authentication_jwt(login);

            if (RESULT == null)
            {
                return Unauthorized();
            }
            else
            {
                return Ok(RESULT);
            }


        }




    }
}
