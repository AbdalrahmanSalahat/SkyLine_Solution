using SkyLine_DAL.Db_ContextFolder;
using SkyLine_DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyLine_DAL.Repositories.Classes
{
   public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        public ApplicationDbContext ApplicationDbContext { get; set; }
        public GenericRepository(ApplicationDbContext applicationDbContext)
        {
            ApplicationDbContext = applicationDbContext;
        }

        public int Add(TEntity entity)
        {
            ApplicationDbContext.Set<TEntity>().Add(entity);
            return ApplicationDbContext.SaveChanges();
        }

        public int Delete(TEntity entity)
        {
             ApplicationDbContext.Set<TEntity>().Remove(entity); 
            return ApplicationDbContext.SaveChanges();

        }

        public TEntity GetbyId(int Id)
        {
            return ApplicationDbContext.Set<TEntity>().Find(Id);        }

        public int Update(TEntity entity)
        {
            ApplicationDbContext.Set<TEntity>().Update(entity);
            return ApplicationDbContext.SaveChanges();
        }

        public List<TEntity> GetAll()
        {
            return ApplicationDbContext.Set<TEntity>().ToList();
        }
    }
}
