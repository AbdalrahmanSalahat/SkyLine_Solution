using SkyLine_DAL.DTO_s.Requests;
using SkyLine_DAL.DTO_s.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyLine_BLL.Services.Interfaces
{
  public  interface IAuthenticationService
    {
        public Task<TokenResponse> Login(LoginRequest loginRequest);
        public Task<MessageResponse> Register(RegisterRequest register);

    }
}
