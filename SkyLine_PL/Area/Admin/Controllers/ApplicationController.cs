using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SkyLine_BLL.Services.Interfaces;
using SkyLine_DAL.DTO_s.Responses;
using SkyLine_DAL.Models;
using System.Security.Claims;

namespace SkyLine_PL.Area.Admin.Controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationService applicationService;

        public ApplicationController(IApplicationService applicationService)
        {
            this.applicationService = applicationService;
        }
        [HttpGet("GetAllApplications")]
        public async Task<List<JobResponse>> GetAllApplications(string? userId)
        {

            return await applicationService.GetAllApplications(userId);
        }

        [HttpGet("PendingApplication")]
        [AllowAnonymous]
        public List<Applied_Jobs> PendingApplication(string JobName, string? userId, bool? isAppoved)
        {
            return applicationService.GetPendingApplications(JobName, userId, isAppoved);
        }
    }
}
