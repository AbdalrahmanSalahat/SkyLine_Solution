using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using SkyLine_BLL.Services.Interfaces;
using SkyLine_DAL.DTO_s.Responses;
using SkyLine_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SkyLine_BLL.Services.Classes
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> userManager;

        public AccountService(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<UserResponse> Profile(string user)
        {
       var User= await userManager.FindByIdAsync(user);
            if (User == null)
            {
                throw new Exception("User not found");
            }
            return new UserResponse
            {
              
                Name = User.Name,
                Email = User.Email,
                PhoneNumber = User.PhoneNumber,
                ResumeURL = User.ResumeURL,
                userName = User.UserName
            };
        }

        public async Task<MessageResponse> Uploadcv(IFormFile file, string user)
        {
            var Uploadeduser = await userManager.FindByIdAsync(user);
            if (Uploadeduser == null) {
                throw new Exception("User not found");
            }
            var Allowedextensions = new[] { ".pdf", ".doc", ".docx" };
            var getextension = Path.GetExtension(file.FileName).ToLower();
            if (!Allowedextensions.Contains(getextension))
            {
                throw new Exception("File extension is not allowed");
            }

            var fileName = $"{Guid.NewGuid()}{getextension}";

            var uploadsFolder = Path.Combine(
                                 Directory.GetCurrentDirectory(),
                                 "wwwroot",
                                     "cvs"
);
            Directory.CreateDirectory(uploadsFolder);
            var filePath = Path.Combine(uploadsFolder, fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            Uploadeduser.ResumeURL = $"/cvs/{fileName}";

            await userManager.UpdateAsync(Uploadeduser);

            return new MessageResponse { Message = "CV uploaded successfully" };


        }
    }
}
