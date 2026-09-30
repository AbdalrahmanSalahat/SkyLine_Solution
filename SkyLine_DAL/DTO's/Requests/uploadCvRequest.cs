using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyLine_DAL.DTO_s.Requests
{
  public class uploadCvRequest
    {
        public int UserId { get; set; }
        public IFormFile Cv { get; set; }
    }
}
