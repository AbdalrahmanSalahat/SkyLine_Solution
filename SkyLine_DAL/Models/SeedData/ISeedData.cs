using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyLine_DAL.Models.SeedData
{
    public interface ISeedData
    {
        public Task SeedUser();
        public Task SeedMigration();
    }
}
