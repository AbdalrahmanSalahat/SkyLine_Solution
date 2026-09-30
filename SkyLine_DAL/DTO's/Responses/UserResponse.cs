using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyLine_DAL.DTO_s.Responses
{
   public class UserResponse
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string? ResumeURL { get; set; }
        public string PhoneNumber { get; set; }
        public string userName { get; set; }
    }
}
