using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyLine_DAL.Models
{
   public class ApplicationUser:IdentityUser
    {
        public string Name { get; set; }
        public string? ResumeURL { get; set; }

    }
}
