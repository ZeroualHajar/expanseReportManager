using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExpanseReportManager.Models;
using ExpanseReportManager.Services;

namespace ExpanseReportManager.Controllers
{
    public class TvaController : AbstractController
    {
        private TvaService Service;

        public TvaController() : base()
        {
            this.Service = new TvaService(this.Entities);
        }

        // GET: Tva
        public ActionResult Index()
        {
            return View(Service.GetAll());
        }

        [HttpPost]
        public ActionResult CreateEdit(TvaViewModels model)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(model.TVA_ID))
                {
                    Service.Add(model);
                }
                else
                {
                    Service.Edit(model);
                }

                return RedirectToAction("Index");
            }

            return View("Create", model);
        }

        public ActionResult Create()
        {
            return View(new TvaViewModels());
        }

        public ActionResult Edit(string id)
        {
            TvaViewModels tva = Service.GetById(id);

            // To show Tva value in percent in form
            tva.Value = tva.Value * 100;

            return View("Create", tva);
        }

        public ActionResult Details(string id)
        {
            return View(Service.GetById(id));
        }
        public ActionResult Delete(string id)
        {
            Service.Delete(id);

            return RedirectToAction("index");
        }

        public ActionResult TvaSearch(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                return PartialView("_TableList", Service.GetAll());
            }
            else
            {
                return PartialView("_TableList", Service.Search(query));
            }
        }

    }
}