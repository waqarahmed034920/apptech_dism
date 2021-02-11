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
    public class OptionTypeController : Controller
    {
        IOptionTypeRepository optionTypeRepository;
        public OptionTypeController(IOptionTypeRepository repo)
        {
            optionTypeRepository = repo;
        }
        // GET: OptionType
        public ActionResult Index()
        {
            List<OptionType> modelList = this.optionTypeRepository.GetAll();
            return View(modelList);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(OptionType model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    this.optionTypeRepository.Insert(model);
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
            OptionType model = this.optionTypeRepository.GetById(id);
            return View(model);
        }

        [HttpPost]public ActionResult Edit(OptionType model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    this.optionTypeRepository.Insert(model);
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

        public ActionResult Delete(int id)
        {
            this.optionTypeRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}