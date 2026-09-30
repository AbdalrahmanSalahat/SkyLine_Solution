using Microsoft.AspNetCore.Http;
using SkyLine_DAL.DTO_s.Responses;
using SkyLine_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyLine_BLL.Services.Interfaces
{
 public interface IAccountService
    {
        public Task<UserResponse> Profile(string user);
        public Task<MessageResponse> Uploadcv(IFormFile file,string user);
    }
}
