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
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Support()
        {
            return View();
        }

        public ActionResult Faq()
        {
            IRepository<FAQ> faqRepo = new FAQRepository();
            var model = faqRepo.GetAll();
            return View(model);
        }

    }
}