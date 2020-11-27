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
    public class SurveyQuestionController : Controller
    {

        IRepository<OptionType> optionTypeRepository = new OptionTypeRepository();
        IRepository<Survey> surveyRepository = new SurveyRepository();
        IRepository<SurveyQuestion> surveyQuestionRepository = new SurveyQuestionRepository();
        // GET: SurveyQuestion
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddQuestion(int SurveyId)
        {
            List<OptionType> lstOptions = this.optionTypeRepository.GetAll();
            lstOptions.Insert(0, new OptionType() { Id = 0, Name = "Please select" });

            Survey objSurvey = this.surveyRepository.GetById(SurveyId);
            ViewBag.ListOfOptionTypes = lstOptions;
            ViewBag.Message = "Adding questions in survey: " + objSurvey.Name;
            return View();
        }
    }
}