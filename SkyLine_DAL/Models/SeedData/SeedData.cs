using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SkyLine_DAL.Db_ContextFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyLine_DAL.Models.SeedData
{
    public class SeedData : ISeedData
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ApplicationDbContext context;
        public readonly RoleManager<IdentityRole> RoleManager;
        public SeedData(UserManager<ApplicationUser> userManager,RoleManager<IdentityRole> roleManager,ApplicationDbContext context)
        {
            this.userManager = userManager;
            RoleManager = roleManager;
            this.context = context;
        }



        public async Task SeedMigration()
        {
           
          throw new NotImplementedException();


        }

        public async Task SeedUser()
        { 
            if (!await context.Roles.AnyAsync())
            {
                var role1 = new IdentityRole()
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                };

                var role2 = new IdentityRole()
                {
                    Name = "Customer",
                    NormalizedName = "CUSTOMER"
                };
               await RoleManager.CreateAsync(role1);
               await RoleManager.CreateAsync(role2);
              
               
            }
            if (! await context.Users.AnyAsync()) {
                var user = new ApplicationUser()
                {
                    Name = "Admin",
                    UserName = "Admin_Alharbi",
                    PhoneNumber = "078965432324",
                    Email = "Abd1234@gmail.com"
                };

                var user2 = new ApplicationUser()
                {
                    Name = "Customer",
                    UserName = "Customer_Ali",
                    PhoneNumber = "0785897552",
                    Email = "Abdc1234@gmail.com"
                };
                await userManager.CreateAsync(user, "@Abd1234");
                await userManager.CreateAsync(user2, "@Abd1234");
                await userManager.AddToRoleAsync(user, "Admin");
                await userManager.AddToRoleAsync(user2, "Customer");
            }
             await context.SaveChangesAsync();

        }
    }
}
