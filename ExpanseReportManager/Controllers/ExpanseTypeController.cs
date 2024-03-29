﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExpanseReportManager.Services;
using ExpanseReportManager.Models;

namespace ExpanseReportManager.Controllers
{
    [CustomAuthorize(Roles = "SuperAdmin, Ressource Humaine")]
    public class ExpanseTypeController : AbstractController
    {
        private ExpanseTypeService Service;
        private TvaService TvaService;

        public ExpanseTypeController() : base()
        {
            this.Service = new ExpanseTypeService(this.Entities);
            this.TvaService = new TvaService(this.Entities);
        }

        // GET: ExpanseType
        public ActionResult Index()
        {
            return View(Service.GetAll());
        }

        public ActionResult Search(string query)
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

        [HttpPost]
        public ActionResult CreateEdit(ExpanseTypeViewModels model)
        {
            if (!Service.IsValid(model))
            {
                ModelState.AddModelError("Fixed", "Vous avez choisi une valeur fixe. Le plafond est donc obligatoire");
            }

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
            ViewBag.Tva = new SelectList(TvaService.GetAll(), "TVA_ID", "Name");

            return View(new ExpanseTypeViewModels());
        }

        public ActionResult Edit(string id)
        {
            ExpanseTypeViewModels model = Service.GetById(id);
            if (model == null)
            {
                return new HttpStatusCodeResult(404);
            }

            ViewBag.Tva = new SelectList(TvaService.GetAll(), "TVA_ID", "Name");

            return View("Create", model);
        }

        public ActionResult Delete(string id)
        {
            Service.Delete(id);

            return RedirectToAction("Index");
        }

        public ActionResult Details(string id)
        {
            ExpanseTypeViewModels model = Service.GetById(id);
            if (model == null)
            {
                return new HttpStatusCodeResult(404);
            }

            return View(model);
        }
    }
}