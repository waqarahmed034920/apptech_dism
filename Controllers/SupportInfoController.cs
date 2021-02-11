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
    public class SupportInfoController : Controller
    {
        ISupportInfoRepository supportInfoRepo;
        public SupportInfoController(ISupportInfoRepository supportInfoRepository)
        {
            supportInfoRepo = supportInfoRepository;
        }
        // GET: SupportInfo
        public ActionResult ManageSupport()
        {
            var supportInfoList = this.supportInfoRepo.GetAll();
            return View(supportInfoList);
        }

        public ActionResult Edit(int id)
        {
            var supportInfo = this.supportInfoRepo.GetById(id);
            return View(supportInfo);
        }

        [HttpPost]
        public ActionResult Edit(SupportInfo model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    this.supportInfoRepo.Update(model);
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
            return View();
        }
        [HttpPost]
        public ActionResult Create(SupportInfo model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    this.supportInfoRepo.Insert(model);
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