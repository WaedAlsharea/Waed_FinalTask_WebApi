using learn.core.Data;
using learn.core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Nancy.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Waed_FinalTask_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService CategoryService;
    
        public CategoryController(ICategoryService CategoryService)
        {
            this.CategoryService = CategoryService;
         
        }

        //Insert any number of objects no only 5 :)
        [HttpPost("createList")]
        public IActionResult ListOfCat([FromBody] List<CategoryApii> categories)
        {

            foreach (var item in categories)
            {
                bool value = this.CategoryService.createCategory(item);
            }
            return Ok();
        }
        [HttpPost("CreateCategory")]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryApii category)
        {
            try
            {
                var done = Task.Run(() => CategoryService.createCategory(category));
                await Task.WhenAll(done);
                if (done.Result)
                    return new JsonResult("Category Created");

                else
                    return BadRequest();
            }

            catch (Exception ex)
            {
                return new JsonResult(ex.Message.ToString());
            }

        }




        [HttpPut("UpdateCategory/{id}")]
        public async Task<IActionResult> UpdateCategory([FromBody] CategoryApii category, int id)
        {
            try
            {
                var done = Task.Run(() => CategoryService.updateCategory(category, id));
                await Task.WhenAll(done);

                if (done.Result)
                    return new JsonResult("Category Updated");

                else
                    return new JsonResult("The Category Id deos not exist");
            }
            catch (Exception ex)
            {

                return new JsonResult(ex.Message.ToString());
            }
        }
        [HttpDelete("DeleteCategory/{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            try
            {
                var done = Task.Run(() => CategoryService.deleteCategory( id));
                await Task.WhenAll(done);

                if (done.Result)
                    return new JsonResult("Category Deleted");

                else
                    return new JsonResult("The Category Id deos not exist");

            }
            catch (Exception ex)
            {

                return new JsonResult(ex.Message.ToString());
            }
        }
        [HttpGet("GetCategories")]
        public async Task<IActionResult> GetCategories()
        {
            try
            {
                //It retun the categories beside with the Execution State :\
               var categories = Task.Run(() => CategoryService.getallCategories() );
                await Task.WhenAll(categories);

                if (categories != null)
                    return new JsonResult(categories);
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
