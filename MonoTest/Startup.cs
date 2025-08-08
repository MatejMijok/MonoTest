using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using MonoTest.Models;
using Owin;

[assembly: OwinStartupAttribute(typeof(MonoTest.Startup))]
namespace MonoTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesAndUsers();
        }

        public void CreateRolesAndUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!roleManager.RoleExists("admin"))
            {
                var role = new IdentityRole("admin");
                roleManager.Create(role);

                var user = new ApplicationUser()
                {
                    UserName = "matej@admin.com",
                    Email = "matej@admin.com"
                };

                string userPassword = "Admin123!";
                var chkUser = UserManager.Create(user, userPassword);

                if (chkUser.Succeeded)
                {
                    var result = UserManager.AddToRole(user.Id, "admin");
                }
            }
        }
    }
}