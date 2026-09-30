using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkyLine_BLL.Services.Interfaces;
using SkyLine_DAL.DTO_s.Requests;

namespace SkyLine_PL.Area.Admin.Controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Area("Admin")]
    public class ManageController : ControllerBase
    {
        private readonly IManagementService service;

        public ManageController(IManagementService service)
        {
            this.service = service;
        }
        [HttpPost("Create")]
        public IActionResult AddNewJob(JobRequest jobRequest)
        {
            return Ok(service.AddJob(jobRequest));
        }
        [HttpGet("All")]

        public IActionResult GetAllJobs()
        {
            return Ok(service.GetAllJobs());
        }


        [HttpGet("GetByID/{id}")]

        public IActionResult GetjobById(int id)
        {
            return Ok(service.GetJobById(id));
        }

        [HttpPut("Update/{id}")]

        public IActionResult UpdateJob(int id,JobRequest model)
        {
            return Ok(service.UpdateJob(id, model));
        }

        [HttpGet("Delete/{id}")]

        public IActionResult DeleteJob(int id)
        {
            return Ok(service.DeleteJob(id));
        }
     
    }
}
