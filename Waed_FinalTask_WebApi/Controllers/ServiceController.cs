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
    public class ServiceController : ControllerBase
    {

        private readonly IServiceService ServiceService;
        public ServiceController(IServiceService ServiceService)
        {
            this.ServiceService = ServiceService;

        }



        [HttpPost("CreateService")]
        public IActionResult CreatePayment([FromBody] ServiceApi service)
        {
            try
            {
                bool result = ServiceService.createService(service);
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

        [HttpDelete("DeleteService")]
        public IActionResult DeleteService(int id)
        {
            try
            {

                bool result = ServiceService.deleteService(id);
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
        [HttpPost("GetServices")]
        public IActionResult GetServices()
        {
            try
            {
                IEnumerable<ServiceApi> services = this.ServiceService.getallServices();
                if (services != null)
                    return new JsonResult(services);
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }

        }


        [HttpDelete("UpdateService")]
        public IActionResult UpdateService([FromBody] ServiceApi service,int id)
        {
            try
            {
                bool result = ServiceService.updateService(service, id);
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
















    }
}
