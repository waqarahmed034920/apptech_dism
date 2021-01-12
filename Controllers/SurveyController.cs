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
        ICompetition competitionRepo;

        public SurveyController()
        {
            surveyRepository = new SurveyRepository();
            surveyQuestionRepository = new SurveyQuestionRepository();
            this.competitionRepo = new CompetitionRepository();
        }

        public ActionResult SurveyBoard()
        {
            Competition currentCompetition = competitionRepo.GetCurrentCompetition();
            return View(currentCompetition);
        }
        // GET: Survey
        public ActionResult Manage()
        {
            List<Survey> lst = this.surveyRepository.GetAll();
            return View(lst);
        }


        [Authorize]
        public ActionResult Participate(int SurveyId)
        {
            Survey survey = this.surveyRepository.GetById(SurveyId);
            List<SurveyQuestion> questions = this.surveyQuestionRepository.GetQuestionsBySurveyId(SurveyId);
            ViewModelSurveyQuestion viewModel = new ViewModelSurveyQuestion();
            viewModel.Survey = survey;
            viewModel.Questions = questions;
            return View(viewModel);
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
            ViewBag.SurveyForRole = GetSurveyForRoleList();
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
                ViewBag.SurveyForRole = GetSurveyForRoleList();
                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(model);
            }
        }

        private List<SelectListItem> GetSurveyForRoleList()
        {
            List<SelectListItem> lst = new List<SelectListItem>();
            lst.Add(new SelectListItem() { Text = "Faculty or Staff", Value = "Faculty or Staff" });
            lst.Add(new SelectListItem() { Text = "Students", Value = "Students" });
            return lst;
        }
        public ActionResult Create()
        {
            ViewBag.SurveyForRole = GetSurveyForRoleList();
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
                ViewBag.SurveyForRole = GetSurveyForRoleList();
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