using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExpanseReportManager.Services;
using ExpanseReportManager.Models;

namespace ExpanseReportManager.Controllers
{
    public class ExpanseTypeController : Controller
    {
        ExpanseTypeService Service;
        TvaService TvaService;

        public ExpanseTypeController()
        {
            this.Service = new ExpanseTypeService();
            this.TvaService = new TvaService();
        }

        // GET: ExpanseType
        public ActionResult Index()
        {
            ICollection<ExpanseTypeViewModels> clients = Service.GetAll();

            return View(clients);
        }

        public ActionResult Search(string query)
        {
            ICollection<ExpanseTypeViewModels> list;
            if (string.IsNullOrEmpty(query))
            {
                list = Service.GetAll();
            }
            else
            {
                list = Service.Search(query);
            }

            return PartialView("_TableList", list);
        }

        [HttpPost]
        public ActionResult CreateEdit(ExpanseTypeViewModels model)
        {
            if (ModelState.IsValid && Service.IsValid(model))
            {
                if (string.IsNullOrEmpty(model.Id))
                {

                    Service.Add(model);
                }
                else
                {
                    Service.Edit(model);
                }

                return RedirectToAction("Index");
            }

            ViewBag.Tva = new SelectList(TvaService.GetAll(), "TVA_ID", "Name");

            return View("Create", model);
        }

        public ActionResult Create()
        {
            ExpanseTypeViewModels project = new ExpanseTypeViewModels();

            ViewBag.Tva = new SelectList(TvaService.GetAll(), "TVA_ID", "Name");

            return View(project);
        }

        public ActionResult Edit(string id)
        {
            ExpanseTypeViewModels project = Service.GetById(id);

            ViewBag.Tva = new SelectList(TvaService.GetAll(), "TVA_ID", "Name");

            return View("Create", project);
        }

        public ActionResult Delete(string id)
        {
            Service.Delete(id);
            return RedirectToAction("Index");
        }
    }
}