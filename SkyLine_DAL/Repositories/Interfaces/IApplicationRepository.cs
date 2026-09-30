using SkyLine_DAL.DTO_s.Responses;
using SkyLine_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyLine_DAL.Repositories.Interfaces
{
   public interface IApplicationRepository
    {
        public Job FindJob(string Name);
        public int Submit(Applied_Jobs applied_Jobs);
        public List<Applied_Jobs> GetApplications(ApplicationUser? applicationUser);
        public List<Applied_Jobs> GetPendingApplications(string JobName, string? userId, bool? isAppoved);
    }
}
