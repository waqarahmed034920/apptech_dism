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
        ISurveyQuestion surveyQuestionRepository = new SurveyQuestionRepository();
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
            ViewBag.SurveyId = SurveyId;
            return View();
        }

        [HttpPost]
        public ActionResult Insert(FormCollection form)
        {
            try
            {
                SurveyQuestion question = new SurveyQuestion();
                question.Question = form["Question"];
                question.SurveyId = Convert.ToInt32(form["SurveyId"]);
                question.OptionTypeId = Convert.ToInt32(form["OptionTypeId"]);
                question.NoOfOptions = Convert.ToInt32(form["NoOfOptions"]);
                string options = "";
                foreach(var k in form.Keys)
                {
                    if (k.ToString().IndexOf("option_") > -1)
                    {
                        options += form[k.ToString()] + "!";
                    }
                }
                question.Options = options.TrimEnd('!');
                bool output = surveyQuestionRepository.Insert(question);
                return RedirectToAction("Manage", "Survey");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}