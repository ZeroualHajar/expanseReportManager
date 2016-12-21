using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExpanseReportManager.Models;
using ExpanseReportManager.Services;

namespace ExpanseReportManager.Controllers
{
    public class TvaController : Controller
    {
        TvaService Service;

        public TvaController()
        {
            this.Service = new TvaService();
        }
        // GET: Tva
        public ActionResult Index()
        {
            ICollection<TvaViewModels> tvas = Service.GetAll();

            return View(tvas);
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
            TvaViewModels tva = new TvaViewModels();

            return View(tva);
        }

        public ActionResult Edit(string id)
        {
            TvaViewModels tva = Service.GetById(id);

            // Pour affichage en pourcentage
            tva.Value = tva.Value * 100;

            return View("Create", tva);
        }

        public ActionResult Details(string id)
        {
            TvaViewModels tva = Service.GetById(id);
            
            return View(tva);
        }
        public ActionResult Delete(string id)
        {
            Service.Delete(id);
            return RedirectToAction("index");
        }

        public ActionResult TvaSearch(string query)
        {
            ICollection<TvaViewModels> list;
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

    }
}