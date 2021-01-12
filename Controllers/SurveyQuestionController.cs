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

        IRepository<Survey> surveyRepository;
        ISurveyQuestion surveyQuestionRepository;
        //constructor
        public SurveyQuestionController()
        {
            surveyRepository = new SurveyRepository();
            surveyQuestionRepository = new SurveyQuestionRepository();
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
            List<Option> lstOptions = model.Options;

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
                SurveyQuestion question = new SurveyQuestion();
                question.Id = Convert.ToInt32(form["Id"]);
                question.Question = form["Question"];
                question.SurveyId = Convert.ToInt32(form["SurveyId"]);
                ViewBag.SurveyId = question.SurveyId;
                Survey objSurvey = this.surveyRepository.GetById(question.SurveyId);
                ViewBag.ListOfOptionTypes = null;
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

            Survey objSurvey = this.surveyRepository.GetById(SurveyId);
            ViewBag.ListOfOptionTypes = null;
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