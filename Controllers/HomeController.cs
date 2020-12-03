using SurveyPortal.Infrastructure.Interface;
using SurveyPortal.Infrastructure.Repositories;
using SurveyPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SurveyPortal.Controllers
{
    public class HomeController : Controller
    {
        ICompetition competitionRepo;
        IRepository<FAQ> faqRepo;
        public HomeController()
        {
            this.competitionRepo = new CompetitionRepository();
            this.faqRepo = new FAQRepository();
        }
        public ActionResult Index()
        {
            Competition currentCompetition = competitionRepo.GetCurrentCompetition();
            return View(currentCompetition);
        }

        public ActionResult Support()
        {
            return View();
        }

        public ActionResult Faq()
        {
            var model = faqRepo.GetAll();
            return View(model);
        }

    }
}