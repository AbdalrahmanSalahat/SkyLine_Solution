using Azure.Core;
using Mapster;
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
    public class GenericService<TRequest, TResponse, TEntity> : IGenericService<TRequest, TResponse,TEntity> where TEntity : class
    {
        private readonly IGenericRepository<TEntity> repo;

        public GenericService(IGenericRepository<TEntity> repo)
        {
            this.repo = repo;
        }
        public int Add(TRequest entity)
        {
            repo.Add(entity.Adapt<TEntity>());
            return 1;
        }

        public int Delete(int id)
        {
            var getuser = repo.GetbyId(id);
            if (getuser == null)
            {
                throw new Exception("No data found");
            }

            var Delete = repo.Delete(getuser);
           
            return Delete; 

        }

        public List<TResponse> GetAll()
        {var GetAll = repo.GetAll();
            if(GetAll == null)
            {
                throw new Exception("No data found");
            }

            return GetAll.Adapt<List<TResponse>>();

        }

        public TResponse GetbyId(int Id)
        {
var getUser = repo.GetbyId(Id);
            if (getUser == null)
            {
                throw new Exception("No data found");
            }
            return getUser.Adapt<TResponse>(); 
        }

        public int Update(int Id, TRequest entity)
        {
            var getUser = repo.GetbyId(Id);
            if (getUser == null)
            {
                throw new Exception("No data found");
            }
        
           return repo.Update(entity.Adapt<TEntity>());

        }
    }
}
