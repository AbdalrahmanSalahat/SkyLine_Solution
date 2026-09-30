using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyLine_DAL.Repositories.Interfaces
{
   public interface IGenericRepository<TEntity> where TEntity : class 
    {
        public int Add(TEntity entity);
        public int Delete(TEntity entity);
        public TEntity GetbyId(int Id);
        public int Update( TEntity entity);
        public List<TEntity> GetAll();
    }
}
