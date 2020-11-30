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
            List<SurveyQuestion> questions = this.surveyQuestionRepository.GetQuestionsBySurveyId(id);
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

        [HttpPost]
        public ActionResult Edit(Survey model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool output = this.surveyRepository.Update(model);
                    ViewBag.Message = "Record updated successfully.";
                }
                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(model);
            }
        }

        public ActionResult Create()
        {
            Survey model = new Survey();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(Survey model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool output = this.surveyRepository.Insert(model);
                    ViewBag.Message = "Record addded successfully.";
                }
                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(model);
            }
        }

    }
}