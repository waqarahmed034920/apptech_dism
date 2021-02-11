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

        IOptionTypeRepository optionTypeRepository;
        ISurveyRepository surveyRepository;
        ISurveyQuestion surveyQuestionRepository;
        //constructor
        public SurveyQuestionController(IOptionTypeRepository otRepo, ISurveyRepository surveyRepo, ISurveyQuestion surveyQuestionRepo)
        {
            optionTypeRepository = otRepo;
            surveyRepository = surveyRepo;
            surveyQuestionRepository = surveyQuestionRepo;
        }
        // GET: SurveyQuestion
        public ActionResult ListOfQuestionBySurvey(int SurveyId)
        {
            List<SurveyQuestion> listSurveyQuestions = this.surveyQuestionRepository.GetQuestionsBySurveyId(SurveyId);
            return View(listSurveyQuestions);
        }

        public ActionResult Delete(int id, int SurveyId)
        {
            this.surveyQuestionRepository.Delete(id);
            return RedirectToAction("ListOfQuestionBySurvey", new { SurveyId = SurveyId});
        }
        public ActionResult Edit(int id)
        {
            SurveyQuestion model = this.surveyQuestionRepository.GetById(id);
            List<OptionType> lstOptions = this.optionTypeRepository.GetAll();
            lstOptions.Insert(0, new OptionType() { Id = 0, Name = "Please select" });

            Survey objSurvey = this.surveyRepository.GetById(model.SurveyId);
            ViewBag.ListOfOptionTypes = lstOptions;
            ViewBag.Heading = "Edit questions in survey: " + objSurvey.Name;
            ViewBag.SurveyId = model.SurveyId;

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(FormCollection form)
        {
            try
            {
                List<OptionType> lstOptions = this.optionTypeRepository.GetAll();
                lstOptions.Insert(0, new OptionType() { Id = 0, Name = "Please select" });

                SurveyQuestion question = new SurveyQuestion();
                question.Id = Convert.ToInt32(form["Id"]);
                question.Question = form["Question"];
                question.SurveyId = Convert.ToInt32(form["SurveyId"]);
                question.OptionTypeId = Convert.ToInt32(form["OptionTypeId"]);
                question.NoOfOptions = Convert.ToInt32(form["NoOfOptions"]);
                ViewBag.SurveyId = question.SurveyId;
                Survey objSurvey = this.surveyRepository.GetById(question.SurveyId);
                ViewBag.ListOfOptionTypes = lstOptions;

                string options = "";
                foreach (var k in form.Keys)
                {
                    if (k.ToString().IndexOf("option_") > -1)
                    {
                        options += form[k.ToString()] + "!";
                    }
                }
                question.Options = options.TrimEnd('!');
                bool output = surveyQuestionRepository.Update(question);
                ViewBag.Message = "Question updated successfully.";
                ViewBag.Heading = "Edit questions in survey: " + objSurvey.Name;
                return View(question);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ActionResult AddQuestion(int SurveyId)
        {
            List<OptionType> lstOptions = this.optionTypeRepository.GetAll();
            lstOptions.Insert(0, new OptionType() { Id = 0, Name = "Please select" });

            Survey objSurvey = this.surveyRepository.GetById(SurveyId);
            ViewBag.ListOfOptionTypes = lstOptions;
            ViewBag.Heading = "Adding questions in survey: " + objSurvey.Name;
            ViewBag.SurveyId = SurveyId;
            return View();
        }

        [HttpPost]
        public ActionResult AddQuestion(FormCollection form)
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
                ViewBag.Message = "Question added to survey.";
                return RedirectToAction("ListOfQuestionBySurvey", new { SurveyId = question.SurveyId });
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}