using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SurveyPortal.Infrastructure.Repositories;
using SurveyPortal.Models;
using System.Collections.Generic;
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
            if (!db.Users.Any(u => u.Email == SurveyPortalConstants.ADMIN_EMAIL))
            {
                var user = new ApplicationUser()
                {
                    UserName = SurveyPortalConstants.ADMIN_EMAIL,
                    Email = SurveyPortalConstants.ADMIN_EMAIL,
                    AdmissionDate = new System.DateTime(1754, 01, 01),
                    HireDate = new System.DateTime(1754, 01, 01),
                    Name = "Waqar Ahmed",
                    EmailConfirmed = true,
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
            // now add faqs
            if (!db.FAQs.Any())
            {
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

        }

        private static void InitCompetition(ApplicationDbContext db, int surveyId)
        {
            db.Competitions.Add(new Competition()
            {
                SurveyId = surveyId,
                Introduction = "We are having a competition for all the APTECH students.",
                Details = "This competition consists of a survey about air pollution in karachi. we want to determin how it effects the locals of karachi.",
                StartDate = new System.DateTime(2020, 12, 20),
                EndDate = new System.DateTime(2020, 12, 25)
            });
            db.SaveChanges();
        }


        private static void InitSurvey(ApplicationDbContext db)
        {

            // now add survey.
            if (!db.Surveys.Any())
            {

                Survey survey = new Survey();
                survey.Name = "Environmental Pollution In Karachi.";
                survey.Description = "This survey determines the view points of karachiates regarding their environmental pollution and how it effects their daily life.";
                survey.StartDate = new System.DateTime(2020, 12, 20);
                survey.EndDate = new System.DateTime(2020, 12, 25);
                survey.Questions = new List<SurveyQuestion>
                {
                    new SurveyQuestion()
                    {
                        Question = "Are you satisfied with the CDA work in your area?",
                        Options = new List<Option>
                        {
                            new Option() { Description = "Yes", Type = OptionType.radio },
                            new Option() { Description = "No", Type = OptionType.radio},
                            new Option() { Description = "Don't Know", Type = OptionType.radio}
                        }
                    },
                    new SurveyQuestion()
                    {
                        Question = "Are you satisfied with the traffic situation in your area?",
                        Options = new List<Option>
                        {
                            new Option() { Description = "Yes", Type = OptionType.radio },
                            new Option() { Description = "No", Type = OptionType.radio},
                            new Option() { Description = "Don't Know", Type = OptionType.radio}
                        }
                    },
                    new SurveyQuestion()
                    {
                        Question = "How clean is the atmosphere in your area?",
                        Options = new List<Option>
                        {
                            new Option() { Description = "Yes", Type = OptionType.radio },
                            new Option() { Description = "No", Type = OptionType.radio},
                            new Option() { Description = "Don't Know", Type = OptionType.radio}
                        }
                    },
                    new SurveyQuestion()
                    {
                        Question = "How long does it take you to commute to APTECH?",
                        Options = new List<Option>
                        {
                            new Option() { Description = "Yes", Type = OptionType.radio },
                            new Option() { Description = "No", Type = OptionType.radio},
                            new Option() { Description = "Don't Know", Type = OptionType.radio}
                        }
                    },
                    new SurveyQuestion()
                    {
                        Question = "Do you have regular water supply in your area?",
                        Options = new List<Option>
                        {
                            new Option() { Description = "Yes", Type = OptionType.radio },
                            new Option() { Description = "No", Type = OptionType.radio},
                            new Option() { Description = "Don't Know", Type = OptionType.radio}
                        }
                    }
                };
                db.Surveys.Add(survey);
                db.SaveChanges();

                InitCompetition(db, survey.Id);
            }

        }


        private static void InitSupportInfo(ApplicationDbContext db)
        {

            if (db.SupportInfoes.Any())
            {
                return;
            }

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