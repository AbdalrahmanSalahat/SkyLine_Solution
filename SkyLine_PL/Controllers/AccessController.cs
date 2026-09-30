using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;
using SkyLine_BLL.Services.Interfaces;
using SkyLine_DAL.DTO_s.Requests;

namespace SkyLine_PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessController : ControllerBase
    {
        private readonly IAuthenticationService authenticationService;

        public AccessController(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }
        [HttpPost("Sign_in")]
        public async Task<IActionResult> SignIn(LoginRequest loginRequest)
        {
            return Ok(await authenticationService.Login(loginRequest));


        }
        [HttpPost("Sign_up")]

        public async Task<IActionResult>SignUp(RegisterRequest registerRequest)
        {
            return Ok(await authenticationService.Register(registerRequest));
            
        }
    }
}
