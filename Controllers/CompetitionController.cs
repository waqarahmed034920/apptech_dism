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
        public CompetitionController()
        {
            competitionRepo = new CompetitionRepository();
        }
        // GET: Competition
        public ActionResult Index()
        {
            List<Competition> competitions = this.competitionRepo.GetAll(); 
            return View(competitions);
        }


        public ActionResult Create()
        {
            var roleList = new List<object>();
            roleList.Add(new { Text = "Faculty or Staff", Value = "1" });
            roleList.Add(new { Text = "Students", Value = "2" });
            ViewBag.RoleList = roleList;
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
            var roleList = new List<object>();
            roleList.Add(new { Text = "Faculty or Staff", Value = "1" });
            roleList.Add(new { Text = "Students", Value = "2" });
            ViewBag.RoleList = roleList;
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