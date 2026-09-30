using SkyLine_BLL.Services.Classes;
using SkyLine_DAL.DTO_s.Requests;
using SkyLine_DAL.DTO_s.Responses;
using SkyLine_DAL.Models;
using SkyLine_DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyLine_BLL.Services.Interfaces
{
    public interface ICategoryService:IGenericService<CategoryRequest,CategoryResponse, Category>  {

       
    }
}
