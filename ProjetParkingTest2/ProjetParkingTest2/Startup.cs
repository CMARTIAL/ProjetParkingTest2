using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using DAL;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjetParkingTest2.Startup))]
namespace ProjetParkingTest2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            //CreateRolesAndUsers();
        }

        private void CreateRolesAndUsers()
        {
            using (ParkingContext context = new ParkingContext())
            {
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

                if (!roleManager.RoleExists("Organisateur"))
                {
                    var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                    role.Name = "Organisateur";
                    roleManager.Create(role);

                    //Here we create a Admin super user who will maintain the website

                    var user = new ApplicationUser();
                    user.UserName = "Administrateur";
                    user.Email = "admin@admin.com";

                    string userPWD = "Administrateur78";

                    var chkUser = userManager.Create(user, userPWD);

                    //Add default User to Role Admin
                    if (chkUser.Succeeded)
                    {
                        var result1 = userManager.AddToRole(user.Id, "Organisateur");
                    }
                }
                if (!roleManager.RoleExists("Convive"))
                {
                    var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                    role.Name = "Convive";
                    roleManager.Create(role);
                }
            }
        }
    }
}
