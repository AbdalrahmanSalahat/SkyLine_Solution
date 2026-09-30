using SkyLine_DAL.DTO_s.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyLine_BLL.Services.Interfaces
{
  public interface IGenericService<TRequest,TResponse,TEntity> where TEntity : class
    {

        public int Add(TRequest entity);
        public int Delete(int id);
        public int Update(int Id, TRequest entity);
        public List<TResponse> GetAll ();
        public TResponse GetbyId(int Id);

    }
}
