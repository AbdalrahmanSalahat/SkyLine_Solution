using SkyLine_DAL.Data.Migrations;
using SkyLine_DAL.Db_ContextFolder;
using SkyLine_DAL.DTO_s.Responses;
using SkyLine_DAL.Models;
using SkyLine_DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyLine_DAL.Repositories.Classes
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly ApplicationDbContext context;

        public ApplicationRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public Job FindJob(string Name)
        {

            return context.Jobs.FirstOrDefault(x => x.Position == Name);


        }

        public List<Applied_Jobs> GetApplications(ApplicationUser? applicationUser)
        {
            if(applicationUser == null)
            {
                return context.Applied_Jobs.ToList();
            }
            return context.Applied_Jobs.Where(x => x.UserId == applicationUser.Id).ToList();
        }

        public List<Applied_Jobs> GetPendingApplications(string JobName,string? userId, bool? isAppoved)
        {
            if (isAppoved == true)
            {
                var data = context.Applied_Jobs.FirstOrDefault(x => x.Job.Position == JobName && x.UserId == userId&&x.IsApproved==ApplicationStatus.Pending);
                if(data == null)
                {
                    throw new Exception("No Data Found");
                }
                    Approved(data);
                return context.Applied_Jobs.Where(x => x.Job.Position == JobName && x.IsApproved == ApplicationStatus.Approved).ToList();


            }
            if (isAppoved == false)
            {
                var data = context.Applied_Jobs.FirstOrDefault(x => x.Job.Position == JobName && x.UserId == userId && x.IsApproved == ApplicationStatus.Pending);
                if (data == null)
                {
                    throw new Exception("No Data Found");
                }
                Rejected(data);
                return context.Applied_Jobs.Where(x => x.Job.Position == JobName && x.IsApproved == ApplicationStatus.Rejected).ToList();
            }
            else
            {
               return context.Applied_Jobs.Where(x => x.Job.Position == JobName && x.IsApproved == ApplicationStatus.Pending).ToList();

            }
        }

        public void Approved(Applied_Jobs applied_Jobs)
        {
         applied_Jobs.IsApproved = ApplicationStatus.Approved;
            context.Applied_Jobs.Update(applied_Jobs);
            context.SaveChanges();

        }

        public void Rejected(Applied_Jobs applied_Jobs)
        {
            applied_Jobs.IsApproved = ApplicationStatus.Rejected;
            context.Applied_Jobs.Update(applied_Jobs);
            context.SaveChanges();

        }

        public int Submit(Applied_Jobs applied_Jobs)
        {
            context.Applied_Jobs.Add(applied_Jobs);
            return context.SaveChanges();
        }
    }
}
