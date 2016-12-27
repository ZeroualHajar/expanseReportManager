using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExpanseReportManager.Services;
using ExpanseReportManager.Models;
using Microsoft.AspNet.Identity;

namespace ExpanseReportManager.Controllers
{
    public class ExpanseReportController : AbstractController
    {
        private ExpanseReportService Service;
        private UserService UserService;

        public ExpanseReportController() : base()
        {
            this.Service = new ExpanseReportService(Entities);
            this.UserService = new UserService(Entities);
        }

        private string GetEmployeeId()
        {
            return UserService.GetEmployeeId(User.Identity.GetUserId());
        }

        public ActionResult Index()
        {
            return View(Service.GetAllCreatedByEmployee(GetEmployeeId()));
        }

        public ActionResult Search(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                return PartialView("_TableList", Service.GetAllCreatedByEmployee(GetEmployeeId()));
            }
            else
            {
                return PartialView("_TableList", Service.SearchForEmployee(GetEmployeeId(), query));
            }
        }

        [HttpPost]
        public ActionResult Create(CreateExpanseReportViewModels model)
        {
            if(model.DateReport > DateTime.Now)
            {
                ModelState.AddModelError("DateReport", "Vous ne pouvez pas créer des notes de frais pour un mois dans le future");
            }

            if (model.Author_ID != model.Employee_ID && model.Employee.Pole.ManagerId != model.Author_ID)
            {
                ModelState.AddModelError("Employee_ID", "Vous n'êtes pas le manager de cette employee");
            }

            if (ModelState.IsValid)
            {
                model.Month = model.DateReport.Month;
                model.Year = model.DateReport.Year;

                Service.Add(model);

                return RedirectToAction("Index");
            }

            return View("Create", model);
        }

        public ActionResult Create()
        {
            string author = GetEmployeeId();
            CreateExpanseReportViewModels report = new CreateExpanseReportViewModels();
            report.Author_ID = author;
            report.CreationDate = DateTime.Now;
            report.StatusCode = 0;

            return View(report);
        }
    }
}