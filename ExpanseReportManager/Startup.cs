using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ExpanseReportManager.Models;

[assembly: OwinStartupAttribute(typeof(ExpanseReportManager.Startup))]
namespace ExpanseReportManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }

        private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
  
            if (!roleManager.RoleExists("SuperAdmin"))
            {
                var role = new IdentityRole();
                role.Name = "SuperAdmin";
                roleManager.Create(role);
                 
                var user = new ApplicationUser();
                user.UserName = "SuperAdmin";
                user.Email = "superadminexpanse@gmail.com";

                string userPWD = "SuperAdmin2016";

                var chkUser = UserManager.Create(user, userPWD);
   
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "SuperAdmin");
                }
            }
        }
        }
}
