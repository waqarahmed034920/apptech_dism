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
        IRepository<OptionType> optionTypeRepository;
        public OptionTypeController()
        {
            optionTypeRepository = new OptionTypeRepository();
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
        public ActionResult Insert(OptionType model)
        {
            if (ModelState.IsValid)
            {
                bool output = this.optionTypeRepository.Insert(model);
                if (output == true)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult Edit(int id)
        {
            OptionType model = this.optionTypeRepository.GetById(id);
            return View(model);
        }

        [HttpPost]public ActionResult Update(OptionType model)
        {
            if (ModelState.IsValid)
            {
                bool output = this.optionTypeRepository.Update(model);
                if (output == true)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(model);
                }
            }
            else
            {
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