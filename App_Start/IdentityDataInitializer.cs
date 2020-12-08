using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SurveyPortal.Models;
using System.Linq;

namespace SurveyPortal.App_Start
{
    public class IdentityDataInitializer
    {
        public static void InitializeData()
        {
            var db = new ApplicationDbContext();
            var userStore = new UserStore<ApplicationUser>(db);
            var userManager = new ApplicationUserManager(userStore);
            var roleStore = new RoleStore<IdentityRole>(db);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            InitRoles(db);
            InitUsers(userManager);
        }

        private static void InitRoles(ApplicationDbContext db)
        {
            if (!db.Roles.Any(r => r.Name == SurveyPortalConstants.ADMIN_ROLL_NAME))
            {
                db.Roles.Add(new IdentityRole(SurveyPortalConstants.ADMIN_ROLL_NAME));
                db.SaveChanges();
            }
            if (!db.Roles.Any(r => r.Name == SurveyPortalConstants.FACULTY_OR_STAFF_ROLL_NAME))
            {
                db.Roles.Add(new IdentityRole(SurveyPortalConstants.FACULTY_OR_STAFF_ROLL_NAME));
                db.SaveChanges();
            }
            if (!db.Roles.Any(r => r.Name == SurveyPortalConstants.STUDENT_ROLL_NAME))
            {
                db.Roles.Add(new IdentityRole(SurveyPortalConstants.STUDENT_ROLL_NAME));
                db.SaveChanges();
            }
        }

        private static void InitUsers(UserManager<ApplicationUser> userManager)
        {
            var db = new ApplicationDbContext();
            if (!db.Users.Any(u => u.UserName == SurveyPortalConstants.ADMIN_USER_NAME))
            {
                var user = new ApplicationUser()
                {
                    UserName = SurveyPortalConstants.ADMIN_USER_NAME,
                    Email = "admin@yahoo.com",
                    AdmissionDate = new System.DateTime(2005, 09, 15),
                    HireDate = new System.DateTime(2005, 09, 15),
                    Name = "Waqar Ahmed",
                    EmailConfirmed = true,
                    RollNo = "00000",
                    ClassName = "Admin class",
                    Specification="he is admin"
                };

                userManager.Create(user, "Test123!");
                userManager.AddToRole(user.Id, SurveyPortalConstants.ADMIN_ROLL_NAME);
                db.SaveChanges();
            }
        }
    }
}