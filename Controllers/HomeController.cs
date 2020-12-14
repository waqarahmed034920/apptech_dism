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
        IRepository<FAQ> faqRepo;
        IRepository<SupportInfo> supportRepo;
        IRepository<Survey> surveyRepo;
        public HomeController()
        {
            this.surveyRepo = new SurveyRepository();
            this.faqRepo = new FAQRepository();
            this.supportRepo = new SupportInfoRepository();
        }
        public ActionResult Index()
        {
            var surveyList = surveyRepo.GetAll();
            return View(surveyList);
        }

        public ActionResult Support()
        {
            var supportList = this.supportRepo.GetAll();
            return View(supportList);
        }

        public ActionResult Faq()
        {
            var model = faqRepo.GetAll();
            return View(model);
        }

    }
}