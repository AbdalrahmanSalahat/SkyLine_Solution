using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkyLine_BLL.Services.Classes;
using SkyLine_BLL.Services.Interfaces;
using SkyLine_DAL.DTO_s.Requests;
using SkyLine_DAL.DTO_s.Responses;
using SkyLine_DAL.Models;
using SkyLine_DAL.Repositories.Interfaces;

namespace SkyLine_PL.Area.Admin.Controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Area("Admin")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService service;

        public CategoryController(ICategoryService service)
        {
            this.service = service;
        }

        [HttpGet("{id}")]
        public IActionResult getCategorybyId(int id)
        {
           
            return Ok( service.GetbyId(id));
        }

        [HttpPost("Create")]
        public IActionResult Add(CategoryRequest Entity)
        {
           service.Add(Entity);
            return Ok();
        }

        [HttpPost("Delete")]
        public IActionResult Delete(int Id)
        {
            
            return Ok(service.Delete(Id));
        }

        [HttpGet("All")]
        public ActionResult<List<CategoryResponse>> GetAll()
        {
        return service.GetAll();
        
        }

        [HttpPut("Update/{id}")]
        public ActionResult<CategoryResponse> Update(int id, CategoryRequest request)
        {
            return Ok(service.Update(id,request));

        }

    }
}
