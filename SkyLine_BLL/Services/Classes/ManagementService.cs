using Mapster;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SkyLine_BLL.Services.Interfaces;
using SkyLine_DAL.Data.Migrations;
using SkyLine_DAL.DTO_s.Requests;
using SkyLine_DAL.DTO_s.Responses;
using SkyLine_DAL.Models;
using SkyLine_DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyLine_BLL.Services.Classes
{
    public class ManagementService : IManagementService
    {
        private readonly IManageRepository manageRepository;

        public ManagementService(IManageRepository manageRepository)
        {
            this.manageRepository = manageRepository;
        }
        public MessageResponse AddJob(JobRequest request)
        {
            manageRepository.AddJob(request.Adapt<Job>());
            return new MessageResponse { Message = "Job added successfully" };
        }

        public int DeleteJob(int id)
        {
            var job = manageRepository.GetJobById(id);
            if (job == null)
            {
                throw new Exception("Job not found");
            }

            return manageRepository.DeleteJob(id);
        }

        public List<Job> GetAllJobs()
        {
            var GetAll = manageRepository.GetAllJobs();
            if (GetAll == null)
            {
                throw new Exception("Job not found");
            }
            return GetAll;
        }

        public Job GetJobById(int id)
        {

            var job = manageRepository.GetJobById(id);
            if(job == null)
            {
                throw new Exception("Job not found");
            }
            return job;
        }

        public int UpdateJob(int id, JobRequest model)
        {
            var job = manageRepository.GetJobById(id);
            if (job == null)
            {
                throw new Exception("Job not found");
            }
            var Jobupdated = new Job()
            {

                Position = model.Position,
                Description = model.Description,
                Requirements = model.Requirements,
                Key_Responsibilities = model.Key_Responsibilities,
                Salary = model.Salary
           


            };
            return manageRepository.UpdateJob(Jobupdated);

        }
    }
}
