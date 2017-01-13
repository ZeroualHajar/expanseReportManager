using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExpanseReportManager.Services;
using ExpanseReportManager.Models;
using Microsoft.AspNet.Identity;
using Rotativa;

namespace ExpanseReportManager.Controllers
{
    [CustomAuthorize(Roles = "Employee, SuperAdmin")]
    public class ExpanseReportController : AbstractController
    {
        private ExpanseReportService Service;
        private UserService UserService;
        private EmployeeService EmployeeService;

        public ExpanseReportController() : base()
        {
            this.Service = new ExpanseReportService(Entities);
            this.UserService = new UserService(Entities);
            this.EmployeeService = new EmployeeService(Entities);
        }

        private string GetEmployeeId()
        {
            return UserService.GetEmployeeId(User.Identity.GetUserId());
        }

        public ActionResult Index()
        {
            return View(Service.GetAllUsingByEmployee(GetEmployeeId()));
        }

        public ActionResult Search(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                return PartialView("_TableList", Service.GetAllUsingByEmployee(GetEmployeeId()));
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

        public ActionResult ToValidateManager()
        {
            if (EmployeeService.IsManager(User.Identity.GetUserId()))
            {
                return View("Index", Service.GetAllToValidateManager(GetEmployeeId()));
            }

            return new HttpStatusCodeResult(403);
        }

        [Authorize(Roles = "Comptable")]
        public ActionResult ToValidateAccounting()
        {
            return View("Index", Service.GetAllToValidateAcounting());
        }

        public ActionResult Details(string id, ExpanseReportViewModels model = null)
        {
            ExpanseReportViewModels report = Service.GetById(id);
            if(report != null)
            {
                ViewBag.Days = new SelectList(report.Days);
                return View(report);
            }

            return new HttpStatusCodeResult(404);
        }

        public ActionResult EmployeeValidation(string id)
        {
            ExpanseReportViewModels report = Service.GetById(id);
            if (report != null)
            {
                if (report.Employee_ID == GetEmployeeId())
                {
                    report.StatusCode = ExpanseReportViewModels.STATUS_WAITING_FOR_MANAGER;
                    Service.Edit(report);
                }
            }

            return RedirectToAction("Index");
        }

        public ActionResult EmployeeValidationForAccouting(string id)
        {
            ExpanseReportViewModels report = Service.GetById(id);
            if (report != null)
            {
                if (report.Employee_ID == GetEmployeeId() && report.StatusCode == ExpanseReportViewModels.STATUS_ACCOUNTING_NEED_CORRECTION)
                {
                    report.StatusCode = ExpanseReportViewModels.STATUS_WAITING_FOR_ACCOUNTING;
                    Service.Edit(report);
                }
            }

            return RedirectToAction("Index");
        }

        public ActionResult Cancelled(string id)
        {
            ExpanseReportViewModels report = Service.GetById(id);
            if (report != null)
            {
                if (report.Employee_ID == GetEmployeeId())
                {
                    report.StatusCode = ExpanseReportViewModels.STATUS_CANCELLED;
                    Service.Edit(report);
                }
            }

            return RedirectToAction("Index");
        }

        [CustomAuthorize(Roles = "Comptable")]
        public ActionResult AskForCorrectionAccounting(string id, string comment)
        {
            if(String.IsNullOrEmpty(comment))
            {
                return Json(new { hasError = true, error = "Veuillez ajoutez un commentaire pour permettre à l'employé de faire ses modifications" });
            }
            else
            {
                ExpanseReportViewModels report = Service.GetById(id);
                if (report != null)
                {
                    report.AccountingComment = comment;
                    report.StatusCode = ExpanseReportViewModels.STATUS_ACCOUNTING_NEED_CORRECTION;
                    Service.Edit(report);
                }

                return Json(new { hasError = false, error = "" });
            }
        }

        [CustomAuthorize(Roles = "Comptable")]
        public ActionResult AccountingValidation(string id)
        {
            ExpanseReportViewModels report = Service.GetById(id);
            if (report != null)
            {
                report.AccountingValidationDate = DateTime.Now;
                report.StatusCode = ExpanseReportViewModels.STATUS_VALIDATED;
                Service.Edit(report);
            }

            return RedirectToAction("ToValidateAccounting");
        }

        public ActionResult AskForCorrectionManager(string id, string comment)
        {
            if (String.IsNullOrEmpty(comment))
            {
                return Json(new { hasError = true, error = "Veuillez ajoutez un commentaire pour permettre à l'employé de faire ses modifications" });
            }
            else
            {
                ExpanseReportViewModels report = Service.GetById(id);
                if (report != null && report.Employee.Pole.ManagerId == GetEmployeeId())
                {
                    report.ManagerComment = comment;
                    report.StatusCode = ExpanseReportViewModels.STATUS_MANAGER_NEED_CORRECTION;
                    Service.Edit(report);
                }

                return Json(new { hasError = false, error = "" });
            }
        }

        public ActionResult ManagerValidation(string id)
        {
            ExpanseReportViewModels report = Service.GetById(id);
            if (report != null && report.Employee.Pole.ManagerId == GetEmployeeId())
            {
                report.ManagerValidationDate = DateTime.Now;
                report.StatusCode = ExpanseReportViewModels.STATUS_WAITING_FOR_ACCOUNTING;
                Service.Edit(report);
            }

            return RedirectToAction("ToValidateManager");
        }

        public ActionResult ExportPDF(string id)
        {
            ExpanseReportViewModels model = Service.GetById(id);
            if (model == null)
            {
                return new HttpStatusCodeResult(404);
            }

            if(model.Employee.UserId != User.Identity.GetUserId() && model.Employee.Pole.Manager.UserId != User.Identity.GetUserId() && !User.IsInRole("Comptable") && !User.IsInRole("Ressource Humaine") && !User.IsInRole("SuperAdmin"))
            {
                return new HttpStatusCodeResult(403);
            }

            return new ViewAsPdf("PdfExport", model.Expanses);
        }
    }
}