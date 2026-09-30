using SkyLine_DAL.Db_ContextFolder;
using SkyLine_DAL.Models;
using SkyLine_DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyLine_DAL.Repositories.Classes
{
   public class CategoryRepository :  GenericRepository<Category> , ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context) { }

    }
}
