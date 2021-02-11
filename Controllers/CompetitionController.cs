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
    public class CompetitionController : Controller
    {
        ICompetition competitionRepo;
        ISurveyRepository surveyRepo;
        public CompetitionController(ICompetition competitionRepository, ISurveyRepository surveyRepository)
        {
            competitionRepo = competitionRepository;
            surveyRepo = surveyRepository;
        }
        // GET: Competition
        public ActionResult Index()
        {
            List<Competition> competitions = this.competitionRepo.GetAll(); 
            return View(competitions);
        }

        List<Survey> getSurveyList()
        {
            List<Survey> lstSurvey = surveyRepo.GetAll();
            lstSurvey.Insert(0, new Survey() { Id = 0, Name = "Please select" });
            return lstSurvey;
        }

        List<object> getRoleList()
        {
            var roleList = new List<object>();
            roleList.Add(new { Text = "Please select", Value = 0 });
            roleList.Add(new { Text = "Faculty or Staff", Value = 1 });
            roleList.Add(new { Text = "Students", Value = 2 });

            return roleList;
        }

        public ActionResult Create()
        {
            ViewBag.RoleList = getRoleList();
            ViewBag.SurveyList = getSurveyList();
            Competition model = new Competition();
            return View(model);
        }

        [HttpPost]public ActionResult Create(Competition model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    this.competitionRepo.Insert(model);
                    ViewBag.Message = "Record addded successfully.";
                }
                ViewBag.RoleList = getRoleList();
                ViewBag.SurveyList = getSurveyList();
                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(model);
            }
        }

        public ActionResult Edit(int id)
        {
            ViewBag.RoleList = getRoleList();
            ViewBag.SurveyList = getSurveyList();
            Competition model = this.competitionRepo.GetById(id);
            return View(model);
        }

        [HttpPost]public ActionResult Edit(Competition model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    this.competitionRepo.Update(model);
                    ViewBag.Message = "Record updated successfully.";
                }
                ViewBag.RoleList = getRoleList();
                ViewBag.SurveyList = getSurveyList();
                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(model);
            }
        }

        public ActionResult Delete(int id)
        {
            this.competitionRepo.Delete(id);
            return RedirectToAction("Index");
        }

    }
}