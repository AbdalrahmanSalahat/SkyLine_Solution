using SkyLine_DAL.DTO_s.Responses;
using SkyLine_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyLine_BLL.Services.Interfaces
{
  public interface IApplicationService
    {
        public JobResponse FindJob(string Name, bool? submit, string user);
        public  Task<List<JobResponse>> GetApplications(string UserId);
        public  Task<List<JobResponse>> GetAllApplications(string? UserId);
        public List<Applied_Jobs> GetPendingApplications(string JobName, string? userId, bool? isAppoved);



    }
}
