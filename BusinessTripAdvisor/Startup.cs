/*
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BusinessTripAdvisor.Startup))]
namespace BusinessTripAdvisor
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
*/
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using BusinessTripAdvisor.Models;

[assembly: OwinStartupAttribute(typeof(BusinessTripAdvisor.Startup))]
namespace BusinessTripAdvisor
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateUserAndRoles();
        }
        public void CreateUserAndRoles()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


            // In Startup iam creating first Admin Role and creating a default Admin User 
            if (!roleManager.RoleExists("Administrator"))
            {

                // first we create Admin rool
                var role = new IdentityRole();
                role.Name = "Administrator";
                roleManager.Create(role);

                //Here we create a Admin super user who will maintain the website				

                var user = new ApplicationUser();
                user.FirstName = "Optimus";
                user.LastName = "Prime";
                user.UserName = "admin@bta.com";
                user.Email = "admin@bta.com";

                string userPWD = "Admin!23";

                var chkUser = UserManager.Create(user, userPWD);

                //Add default User to Role Admin
                if (chkUser.Succeeded)
                {
                    UserManager.AddToRole(user.Id, "Administrator");

                }
            }

            // Creating Traveler role 
            if (!roleManager.RoleExists("Traveler"))
            {
                var role = new IdentityRole();
                role.Name = "Traveler";
                roleManager.Create(role);

            }
        }
    }
}
