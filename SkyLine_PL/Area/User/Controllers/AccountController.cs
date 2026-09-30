using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SkyLine_BLL.Services.Classes;
using SkyLine_BLL.Services.Interfaces;
using SkyLine_DAL.DTO_s.Responses;
using SkyLine_DAL.Models;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SkyLine_PL.Area.User.Controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Area("User")]
    [Authorize(Roles="User")]


    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;

        public AccountController(UserManager<ApplicationUser> userManager, IAccountService accountService)
        {
            this.userManager = userManager;
            AccountService = accountService;
        }

        public IAccountService AccountService {get; set;}

        [HttpGet("Profile")]
        public async Task<ActionResult<UserResponse>> Profile()
        {
            var UserId =User.FindFirstValue(ClaimTypes.NameIdentifier);

            return await AccountService.Profile(UserId);
        }

        [HttpPost("UploadCv")]
        public async Task<ActionResult<MessageResponse>> UploadCv(IFormFile file)
        {
            var user =  User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return await AccountService.Uploadcv(file,user);
        }

    }
}
