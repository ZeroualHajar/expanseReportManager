using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExpanseReportManager.Services;
using ExpanseReportManager.Models;


namespace ExpanseReportManager.Controllers
{
    public class ProjectController : AbstractController
    {
        private ProjectService Service;

        public ProjectController() : base()
        {
            this.Service = new ProjectService(this.Entities);
        }

        // GET: Project
        public ActionResult Index()
        {
            return View(Service.GetAll());
        }

        [HttpPost]
        public ActionResult CreateEdit(ProjectViewModels model)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(model.Project_ID))
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
            return View(new ProjectViewModels());
        }

        public ActionResult Edit(string id)
        {
            return View("Create", Service.GetById(id));
        }

        public ActionResult Details(string id)
        {
            return View(Service.GetById(id));
        }

        public ActionResult Delete(string id)
        {
            Service.Delete(id);

            return RedirectToAction("Index");
        }

        public ActionResult ProjectSearch(string query)
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