using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using SavingLives_WebApp.Models;

[assembly: OwinStartupAttribute(typeof(SavingLives_WebApp.Startup))]
namespace SavingLives_WebApp
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

            var roleManager = new RoleManager<IdentityRole>
                (new RoleStore<IdentityRole>(context));

            //if(!roleManager.RoleExists("Visitor"))
            //{
            //    var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
            //    role.Name = "Visitor";
            //    roleManager.Create(role);
            //}

            //if(!roleManager.RoleExists("Admin"))
            //{
            //    var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
            //    role.Name = "Admin";
            //    roleManager.Create(role);
            //}
            var UserManager = new UserManager<ApplicationUser>
                (new UserStore<ApplicationUser>(context));

            //Creating the First Admin Role and creating a default Admin User

            if (!roleManager.RoleExists("Admin"))
            {
                //First Admin Role
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                //Here we are creating a Admin Super User who will maintain the website

                var user = new ApplicationUser();
                user.UserName = "admin@mtctrust.com";
                user.Email = "admin@mtctrust.com";

                string userPWD = "A@Dmin123";

                var chkUser = UserManager.Create(user, userPWD);

                //Add default user to role admin
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");
                }

                //Creating Manager role
                if (!roleManager.RoleExists("Manager"))
                {
                    var role1 = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                    role1.Name = "Manager";
                    roleManager.Create(role1);
                }

                //Creating Employee role
                if (!roleManager.RoleExists("Employee"))
                {
                    var role2 = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                    role2.Name = "Employee";
                    roleManager.Create(role2);
                }

            }


        }

    }

}
