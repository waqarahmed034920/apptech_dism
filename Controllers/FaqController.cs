using SurveyPortal.Infrastructure.Interface;
using SurveyPortal.Infrastructure.Repositories;
using SurveyPortal.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SurveyPortal.Controllers
{
    public class FaqController : Controller
    {
        IRepository<FAQ> faqRepository;
        public FaqController()
        {
            this.faqRepository = new FAQRepository();
        }
        // GET: Faq
        public ActionResult Index()
        {
            List<FAQ> faqList = this.faqRepository.GetAll();
            return View(faqList);
        }

        public ActionResult Create()
        {
            FAQ model = new FAQ();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(FAQ model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    this.faqRepository.Insert(model);
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
            FAQ model = this.faqRepository.GetById(id);
            return View(model);
        }

        [HttpPost]public ActionResult Edit(FAQ model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    this.faqRepository.Update(model);
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
            this.faqRepository.Delete(id);
            return RedirectToAction("Index");
        }

    }
}