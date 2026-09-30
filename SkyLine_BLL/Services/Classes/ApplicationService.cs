using Mapster;
using Microsoft.AspNetCore.Identity;
using SkyLine_BLL.Services.Interfaces;
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
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly UserManager<ApplicationUser> userManager;

        public ApplicationService(IApplicationRepository applicationRepository,UserManager<ApplicationUser> userManager)
        {
            _applicationRepository = applicationRepository;
            this.userManager = userManager;
        }
        public JobResponse FindJob(string Name, bool? submit, string user)
        {

            var job = _applicationRepository.FindJob(Name);
            if (job == null)
            {

                return null;

            }
            if (submit == null || submit.Value == false)
            {
                return _applicationRepository.FindJob(Name).Adapt<JobResponse>();
            }
            var appliedjob = new Applied_Jobs()
            {
                UserId = user
                ,
                JobId = job.Id
            };
            return _applicationRepository.Submit(appliedjob).Adapt<JobResponse>();




        }

        public async Task<List<JobResponse>> GetAllApplications(string? UserId)
        {
            if (UserId != null)
            {
                var user =await userManager.FindByIdAsync(UserId);
                if (user == null)
                {
                    throw new Exception("No Data Found");
                }
                return _applicationRepository.GetApplications(user).Adapt<List<JobResponse>>();

            }
            return _applicationRepository.GetApplications(null).Adapt<List<JobResponse>>();

        }

        public async Task<List<JobResponse>> GetApplications(string UserId)
        {
            var user =await userManager.FindByIdAsync(UserId);
            if (user == null)
            {
                throw new Exception("No Data Found");
            }
            return  _applicationRepository.GetApplications(user).Adapt<List<JobResponse>>();



        }

        public List<Applied_Jobs> GetPendingApplications(string JobName, string? userId, bool? isAppoved)
        {
            if(JobName == null)
            {
                throw new Exception("Job Name is required");
            }
            return _applicationRepository.GetPendingApplications(JobName, userId, isAppoved).ToList();
        }
    }
}
