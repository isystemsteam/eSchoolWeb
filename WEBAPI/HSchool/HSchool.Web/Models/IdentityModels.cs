using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace HSchool.Web.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public string PasswordQuestion { get; set; }

        public string PasswordQuestionAnswer { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("HSchoolConnectionString", throwIfV1Schema: false)
        {
            Database.SetInitializer(new SchoolDBInitializer());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class SchoolDBInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var result = UserManager.Users.AnyAsync<ApplicationUser>();

            if (!result.Result)
            {
                var applicationUser = new ApplicationUser { Email = "pariventhan1984@gmail.com", UserName = "Pariventhan" };
                string userPassword = string.Format("Pari_15071984");
                UserManager.Create(applicationUser, userPassword);
            }
            base.Seed(context);
        }
    }
}