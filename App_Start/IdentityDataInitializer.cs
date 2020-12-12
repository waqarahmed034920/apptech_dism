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

            InitRoles(db);
            InitUsers(userManager);
            InitOptionType(db);
            InitFAQ(db);
            InitSurvey(db);
            InitSupportInfo(db);
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
                    Email = "admin@getnada.com",
                    AdmissionDate = new System.DateTime(1754, 01, 01),
                    HireDate = new System.DateTime(1754, 01, 01),
                    Name = "Waqar Ahmed",
                    EmailConfirmed = true,
                    RollNo = "00000",
                    ClassName = "Admin class",
                    Specification = "he is admin",
                    RegistrationAccepted = true
                };

                userManager.Create(user, "Test123!");
                userManager.AddToRole(user.Id, SurveyPortalConstants.ADMIN_ROLL_NAME);
                db.SaveChanges();
            }
        }

        private static void InitFAQ(ApplicationDbContext db)
        {
            var rows = from faq in db.FAQs
                       select faq;
            foreach (var row in rows)
            {
                db.FAQs.Remove(row);
            }
            db.SaveChanges();
            // now add faqs

            db.FAQs.Add(new FAQ() { Question = "How to register for the survey?", Answer = "In progress...", UpdatedBy = "Waqar Ahmed", UpdatedOn = System.DateTime.Now });
            db.FAQs.Add(new FAQ() { Question = "How to participate in the survey", Answer = "In progress...", UpdatedBy = "Waqar Ahmed", UpdatedOn = System.DateTime.Now });
            db.FAQs.Add(new FAQ() { Question = "How will I be intimated with the new survey", Answer = "In progress...", UpdatedBy = "Waqar Ahmed", UpdatedOn = System.DateTime.Now });
            db.FAQs.Add(new FAQ() { Question = "What if it gives error, after participating in the entire survey, and clicked on the submit button at the last for submitting the survey", Answer = "In progress...", UpdatedBy = "Waqar Ahmed", UpdatedOn = System.DateTime.Now });
            db.FAQs.Add(new FAQ() { Question = "Why I am unable to participate in the survey? (Two reasons: 1.Not the registered user, and 2.Technical Problem", Answer = "In progress...", UpdatedBy = "Waqar Ahmed", UpdatedOn = System.DateTime.Now });
            db.FAQs.Add(new FAQ() { Question = "Why my registration request is not accepted", Answer = "In progress...", UpdatedBy = "Waqar Ahmed", UpdatedOn = System.DateTime.Now });
            db.FAQs.Add(new FAQ() { Question = "Will there be any benefit if participated in the survey?", Answer = "In progress...", UpdatedBy = "Waqar Ahmed", UpdatedOn = System.DateTime.Now });
            db.FAQs.Add(new FAQ() { Question = "How to participate in the competitions", Answer = "In progress...", UpdatedBy = "Waqar Ahmed", UpdatedOn = System.DateTime.Now });
            db.FAQs.Add(new FAQ() { Question = "What if there are some arrears in participating the survey", Answer = "In progress...", UpdatedBy = "Waqar Ahmed", UpdatedOn = System.DateTime.Now });

            db.SaveChanges();

        }

        private static void InitCompetition(ApplicationDbContext db, int surveyId)
        {
            var rows = from comp in db.Competitions
                       select comp;
            foreach (var row in rows)
            {
                db.Competitions.Remove(row);
            }
            db.SaveChanges();
            // now add competition.

            db.Competitions.Add(new Competition() { 
                RoleId = 2, 
                SurveyId = surveyId, 
                Introduction = "We are having a competition for all the APTECH students.", 
                Details = "This competition consists of a survey about air pollution in karachi. we want to determin how it effects the locals of karachi.", 
                StartDate = new System.DateTime(2020, 12, 20), 
                EndDate = new System.DateTime(2020, 12, 25)
            });
            db.SaveChanges();
        }

        private static void InitOptionType(ApplicationDbContext db)
        {
            var rows = from OT in db.OptionTypes
                       select OT;
            foreach (var row in rows)
            {
                db.OptionTypes.Remove(row);
            }
            db.SaveChanges();

            // now add option types.
            db.OptionTypes.Add(new OptionType() { Name = "Radio", Description = "This would render a radio button." });
            db.OptionTypes.Add(new OptionType() { Name = "Checkbox", Description = "This would render a checkbox." });

            db.SaveChanges();

        }

        private static void InitSurvey(ApplicationDbContext db)
        {
            var rows = from sur in db.Surveys
                       select sur;
            foreach (var row in rows)
            {
                db.Surveys.Remove(row);
            }
            db.SaveChanges();

            // now add survey.
            Survey survey = new Survey();
            survey.BackButton = true;
            survey.InternalOnly = true;
            survey.Reviewable = true;
            survey.Name = "Environmental Pollution In Karachi.";
            survey.Description = "This survey determines the view points of karachiates regarding their environmental pollution and how it effects their daily life.";
            survey.StartDate = new System.DateTime(2020, 12, 20);
            survey.EndDate = new System.DateTime(2020, 12, 25);
            survey.SurveyFor = SurveyPortalConstants.STUDENT_ROLL_NAME;
            db.Surveys.Add(survey);
            db.SaveChanges();

            InitiSurveyQuestion(db, survey.Id);
            InitCompetition(db, survey.Id);
        }

        private static void InitiSurveyQuestion(ApplicationDbContext db, int sId)
        {
            var rows = from ques in db.surveyQuestions
                       select ques;
            foreach (var row in rows)
            {
                db.surveyQuestions.Remove(row);
            }
            db.SaveChanges();

            // now add survey questions.
            db.surveyQuestions.Add(new SurveyQuestion() { Question = "Are you satisfied with the CDA work in your area?", NoOfOptions = 3, Options = "Yes!No!Dont Know", OptionTypeId = 1, SurveyId = sId });
            db.surveyQuestions.Add(new SurveyQuestion() { Question = "Are you satisfied with the traffic situation in your area?", NoOfOptions = 3, Options = "Yes!No!Dont Know", OptionTypeId = 1, SurveyId = sId });
            db.surveyQuestions.Add(new SurveyQuestion() { Question = "How clean is the atmosphere in your area?", NoOfOptions = 3, Options = "Yes!No!Dont Know", OptionTypeId = 1, SurveyId = sId });
            db.surveyQuestions.Add(new SurveyQuestion() { Question = "How long does it take you to commute to APTECH?", NoOfOptions = 3, Options = "Yes!No!Dont Know", OptionTypeId = 1, SurveyId = sId });
            db.surveyQuestions.Add(new SurveyQuestion() { Question = "Do you have regular water supply in your area?", NoOfOptions = 3, Options = "Yes!No!Dont Know", OptionTypeId = 1, SurveyId = sId });

            db.SaveChanges();
        }

        private static void InitSupportInfo(ApplicationDbContext db)
        {
            var rows = from ques in db.SupportInfoes
                       select ques;
            foreach (var row in rows)
            {
                db.SupportInfoes.Remove(row);
            }
            db.SaveChanges();

            db.SupportInfoes.Add(new SupportInfo()
            {
                Contact = "Bill Gates",
                ShortDesc = "Please find the support info below.",
                Description = "If you are stuck in survey at any point or need some information about the competition please goto competition page or contact the following support contact.",
                Email = "b.gates@getnada.com",
                WebAddress = "https://www.aptech.pk",
                Phone = "0092000000",
                WhatsApp = "0000000000",
                SkypeId = "skypeid@getnada.com"
            });

            db.SupportInfoes.Add(new SupportInfo()
            {
                Contact = "Salman Hussain",
                ShortDesc = "Please find the support info below.",
                Description = "If you are stuck in survey at any point or need some information about the competition please goto competition page or contact the following support contact.",
                Email = "s.hussain@getnada.com",
                WebAddress = "https://www.aptech.pk",
                Phone = "0092000000",
                WhatsApp = "0000000000",
                SkypeId = "salman00@gmail.com"
            });

            db.SupportInfoes.Add(new SupportInfo()
            {
                Contact = "Husnain Khan",
                ShortDesc = "Please find the support info below.",
                Description = "If you are stuck in survey at any point or need some information about the competition please goto competition page or contact the following support contact.",
                Email = "h.khan@getnada.com",
                WebAddress = "https://www.aptech.pk",
                Phone = "0092000000",
                WhatsApp = "0000000000",
                SkypeId = "skypeid@getnada.com"
            });

            db.SupportInfoes.Add(new SupportInfo()
            {
                Contact = "Usman Jaffery",
                ShortDesc = "Please find the support info below.",
                Description = "If you are stuck in survey at any point or need some information about the competition please goto competition page or contact the following support contact.",
                Email = "u.jaffery@getnada.com",
                WebAddress = "https://www.aptech.pk",
                Phone = "0092000000",
                WhatsApp = "0000000000",
                SkypeId = "skypeid@getnada.com"
            });
            db.SaveChanges();

        }
    }
}