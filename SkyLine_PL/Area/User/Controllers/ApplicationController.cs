using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SkyLine_BLL.Services.Classes;
using SkyLine_BLL.Services.Interfaces;
using SkyLine_DAL.DTO_s.Responses;
using SkyLine_DAL.Models;
using System.Security.Claims;

namespace SkyLine_PL.Area.User.Controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Area("User")]
    [Authorize(Roles = "User")]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationService applicationService;
        private readonly UserManager<ApplicationUser> userManager;

        public ApplicationController(IApplicationService applicationService,UserManager<ApplicationUser> userManager)
        {
            this.applicationService = applicationService;
            this.userManager = userManager;
        }

        [HttpPost("Search")]
        public IActionResult Seachforjob(string jobName, bool? submit)
        {
            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            return Ok(applicationService.FindJob(jobName, submit, user));
        }



        [HttpGet("MyApplications")]
        public async Task<List<JobResponse>> ReviewMyApplications()
        {
            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            return await applicationService.GetApplications(user);
        }
    }
}
