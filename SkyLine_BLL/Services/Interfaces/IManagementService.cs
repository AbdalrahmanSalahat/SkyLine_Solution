using SkyLine_DAL.DTO_s.Requests;
using SkyLine_DAL.DTO_s.Responses;
using SkyLine_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyLine_BLL.Services.Interfaces
{
  public interface IManagementService
    {
        public MessageResponse AddJob(JobRequest request);
        public List<Job> GetAllJobs();
        public int UpdateJob(int id,JobRequest model);
        public int DeleteJob(int id);
        public Job GetJobById(int id);
    }
}
