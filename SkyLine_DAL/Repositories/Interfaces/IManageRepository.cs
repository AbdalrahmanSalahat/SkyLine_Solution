using SkyLine_DAL.DTO_s.Requests;
using SkyLine_DAL.DTO_s.Responses;
using SkyLine_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyLine_DAL.Repositories.Interfaces
{
   public interface IManageRepository
    {
        public int AddJob(Job model);
        public List<Job> GetAllJobs();
        public int UpdateJob(Job model);
        public int DeleteJob(int id);
        public Job GetJobById(int id);

        
    }
}
