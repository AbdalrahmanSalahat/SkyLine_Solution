using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SkyLine_BLL.Services.Interfaces;
using SkyLine_DAL.DTO_s.Requests;
using SkyLine_DAL.DTO_s.Responses;
using SkyLine_DAL.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SkyLine_BLL.Services.Classes
{
  public class AuthenticationService:IAuthenticationService
    {
        private readonly UserManager<ApplicationUser> userManager;

        public AuthenticationService(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<TokenResponse> Login(LoginRequest loginRequest)
        {
            var user = await userManager.FindByEmailAsync(loginRequest.Email);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            var chkpass=await userManager.CheckPasswordAsync(user, loginRequest.Password);
            if (!chkpass)
            {
                throw new Exception("Invalid password");
            }
            return new TokenResponse
            {
                Token = await GenerateToken(user)
            };


        }

        public async Task<MessageResponse> Register(RegisterRequest register)
        {

            var user = new ApplicationUser
            {
                UserName = register.UserName,
                Email = register.Email,
                Name = register.Name,
                PhoneNumber = register.PhoneNumber
            };
           await userManager.CreateAsync(user, register.Password);
            await userManager.AddToRoleAsync(user, "Customer");
            return new MessageResponse { Message = "User registered successfully" };


        }

        public async Task<string> GenerateToken(ApplicationUser user)
        {
            var userClaims = new List<Claim>
{
    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
    new Claim(ClaimTypes.Name, user.Name!),
    new Claim(ClaimTypes.Email, user.Email!),
    new Claim(ClaimTypes.UserData, user.UserName!)
};
            var roles = await userManager.GetRolesAsync(user);
            foreach (var x in roles)
            {
                userClaims.Add(new Claim(ClaimTypes.Role, x));

            }
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("b983b66aeyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9u"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
            claims: userClaims,
            expires: DateTime.Now.AddDays(5),
            signingCredentials: credentials
        );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}


