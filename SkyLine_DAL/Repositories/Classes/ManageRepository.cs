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
    public class ManageRepository : IManageRepository
    {
        private readonly ApplicationDbContext context;

        public ManageRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public int AddJob(Job model)
        {
            context.Add(model);
            return context.SaveChanges();

        }

        public int DeleteJob(int id)
        {
            context.Remove(id);
            return context.SaveChanges();
        }

        public List<Job> GetAllJobs()
        {
            return context.Jobs.ToList();
        }

        public Job GetJobById(int id)
        {
           return context.Jobs.FirstOrDefault(x => x.Id == id);
        }

        public int UpdateJob(Job model)
        {
            context.Update(model);
            return context.SaveChanges();

        }
    }
}
