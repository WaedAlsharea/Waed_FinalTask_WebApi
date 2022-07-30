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
    public class PaymentController : ControllerBase
    {


        private readonly IPaymentService PaymentService;
        public PaymentController(IPaymentService PaymentService)
        {
            this.PaymentService = PaymentService;

        }



        [HttpPost("CreatePayment")]
        public IActionResult CreateLike([FromBody] PaymentApi payment)
        {
            try
            {
                bool value = this.PaymentService.createPayment(payment);
                if (value)
                    return new JsonResult("Like Payment");
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {

                return new JsonResult(ex.ToString());


            }
        }


        [HttpDelete("DeletePayment/{id}")]

        public IActionResult DeletePayment(int id)
        {
            try
            {
                bool value = this.PaymentService.deletePayment(id);
                if (value)
                    return new JsonResult("Payment Deleted");
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {

                return new JsonResult(ex.ToString());


            }
        }
        [HttpGet("GetPayment")]
        public  IActionResult GetMyLikes()
        {
            try
            {
                IEnumerable<PaymentApi> payments = this.PaymentService.getPayments();

                if (payments != null)
                    return new JsonResult(payments);
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {

                return new JsonResult(ex.ToString());

            }

        }


          [HttpPost("Pay/{userId}/{serviceId}")]
        public IActionResult CreateLike([FromBody] VisaApi visa, int userId, int serviceId)
        {
            try
            {
                bool value = this.PaymentService.updateVisa(visa, userId , serviceId);
                if (value)
                    return new JsonResult(" done");
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {

                return new JsonResult(ex.ToString());


            }
        }


        [HttpGet("TotalSales")]
        public IActionResult TotalSales()
        {
            try
            {
                IEnumerable<YearlySalesDTO> payments = this.PaymentService.TotalSales();

                if (payments != null)
                    return new JsonResult(payments);
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
