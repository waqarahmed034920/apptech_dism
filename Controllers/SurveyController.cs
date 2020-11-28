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
    public class SurveyController : Controller
    {
        IRepository<Survey> surveyRepository;
        ISurveyQuestion surveyQuestionRepository;
        public SurveyController()
        {
            surveyRepository = new SurveyRepository();
            surveyQuestionRepository = new SurveyQuestionRepository();
        }
        // GET: Survey
        public ActionResult Manage()
        {
            List<Survey> lst = this.surveyRepository.GetAll();
            return View(lst);
        }

        public ActionResult Preview(int id)
        {
            Survey survey = this.surveyRepository.GetById(id);
            List<SurveyQuestion> questions = this.surveyQuestionRepository.GetBySurveyId(id);
            ViewModelSurveyQuestion viewModel = new ViewModelSurveyQuestion();
            viewModel.Survey = survey;
            viewModel.Questions = questions;
            return View(viewModel);
        }
        public ActionResult Edit(int id)
        {
            Survey model = this.surveyRepository.GetById(id);
            return View(model);
        }

        public ActionResult UpdateSurvey(Survey model)
        {
            if (ModelState.IsValid)
            {
                bool output = this.surveyRepository.Update(model);
                if (output == true)
                {
                    return RedirectToAction("Manage");
                }
                else
                {
                    return RedirectToAction("Edit", new { id = model.Id });
                }
            }
            else
            {
                return RedirectToAction("Edit", new { id = model.Id });
            }
        }

        public ActionResult Create(Survey model)
        {
            ViewBag.Message = "Create New Survey.";
            return View(model);
        }

        [HttpPost]
        public ActionResult SaveSurvey(Survey model)
        {
            if (ModelState.IsValid)
            {
                bool output = this.surveyRepository.Insert(model);
                if (output == true)
                {
                    return RedirectToAction("Manage");
                }
                else
                {
                    return RedirectToAction("Create", model);
                }
            }
            else
            {
                return RedirectToAction("Create", model);
            }
        }

    }
}