using Azure.Core;
using Azure;
using SkyLine_BLL.Services.Interfaces;
using SkyLine_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkyLine_DAL.DTO_s.Responses;
using SkyLine_DAL.DTO_s.Requests;

namespace SkyLine_BLL.Services.Classes
{
    public class CategoryService : GenericService<CategoryRequest, CategoryResponse, Category>,ICategoryService
    {
        public CategoryService(SkyLine_DAL.Repositories.Interfaces.ICategoryRepository Repo):base(Repo) 
        { 

        }
    
    }
}
