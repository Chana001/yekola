using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MVCPresentationLayer.Models;

namespace MVCPresentationLayer.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MVCPresentationLayer.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MVCPresentationLayer.Models.ApplicationDbContext context)
        {

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            //Check existence of user
            if (context.Users.Any(u => u.UserName == "admin@test.com")) 
                return;

            var user = new ApplicationUser
            {
                UserName = "f002",
                Email = "tash@test.com"
            };

            context.Roles.AddOrUpdate(r => r.Name, new IdentityRole { Name = "Admin" });
            context.Roles.AddOrUpdate(r => r.Name, new IdentityRole { Name = "Player" });

            var result = userManager.Create(user, "Password@1");

            if (result.Succeeded)
            {
                userManager.AddToRole(user.Id, "Admin");
            }
                
            context.SaveChanges();
        }
    }
}
