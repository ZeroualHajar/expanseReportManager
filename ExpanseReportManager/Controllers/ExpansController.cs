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
    public class ExpansController : AbstractController
    {
        private ExpansService Service;
        private ProjectService ProjectService;

        private UserService UserService;
        private ExpanseReportService ExpanseReportService;
        private ExpanseTypeService ExpanseTypeService;

        public ExpansController() : base()
        {
            this.Service = new ExpansService(Entities);
            this.ProjectService = new ProjectService(Entities);
            this.UserService = new UserService(Entities);
            this.ExpanseReportService = new ExpanseReportService(Entities);
            this.ExpanseTypeService = new ExpanseTypeService(Entities);
        }

        [HttpPost]
        public ActionResult Add(ExpansViewModels model)
        {
            if (!ExpanseReportService.CheckDay(model))
            {
                ModelState.AddModelError("Day", "Ce jour ne fait pas parti de ce mois");
            }

            if (Service.CheckAmount(model) > 0)
            {
                ModelState.AddModelError("Amount_HT", "Vous avez dépassez le plafond pour ce frais de " + Service.CheckAmount(model) + "€");
            }


            if (ModelState.IsValid)
            {
                Service.Add(model);
                ExpanseReportService.UpdateAmount(model.ExpanseReport_ID);
            }

            ExpanseReportViewModels report = ExpanseReportService.GetById(model.ExpanseReport_ID);
            ViewBag.Days = new SelectList(report.Days);

            return PartialView("_FormCreateExpanse", model);
        }

        public ActionResult UpdateAmountField(string expanseTypeForAmount)
        {
            ExpanseTypeViewModels type = ExpanseTypeService.GetById(expanseTypeForAmount);
            if (type == null || !type.Fixed)
            {
                return PartialView("_Amount_HT", new ExpansViewModels());
            }
            else
            {
                
                return PartialView("_Amount_HT", new ExpansViewModels { ExpanseType_ID = expanseTypeForAmount, Amount_HT = (double) type.Ceilling });
            }
        }

        private string GetEmployeeId()
        {
            return UserService.GetEmployeeId(User.Identity.GetUserId());
        }

        public ActionResult UpdateExpansList(string id)
        {
            ExpanseReportViewModels report = ExpanseReportService.GetById(id);
            if (report != null)
            {
                if (report.Employee_ID == GetEmployeeId())
                {
                    ViewBag.Days = new SelectList(report.Days);
                    return PartialView("_ExpansTable", report.Expanses);
                }
            }

            return PartialView("_ExpansTable", new List<ExpansViewModels>());
        }

        public ActionResult Delete(string id)
        {
            ExpanseReportViewModels report = Service.GetById(id).ExpanseReport;
            if (report.Employee_ID == GetEmployeeId())
            {
                Service.Delete(id);
                ExpanseReportService.UpdateAmount(report.ExpanseReport_ID);

                return Json(new { action = "removed", removed = true, error = "" });
            }

            return Json(new { action = "removed", removed = false, error = "Ce frais ne correspond pas au votre" });
        }

        public ActionResult Edit(string id, string price)
        {
            ExpansViewModels expans = Service.GetById(id);

            expans.Amount_HT = Convert.ToDouble(price);
            if (Service.CheckAmount(expans) > 0)
            {
                string error = " : Vous avez dépassez le plafond pour ce frais de " + Service.CheckAmount(expans) + "€";
                return Json(new { action = "edit", removed = false, error = error });
            }

            if (expans.ExpanseReport.Employee_ID == GetEmployeeId())
            {
                Service.Edit(expans);
                ExpanseReportService.UpdateAmount(expans.ExpanseReport_ID);

                return Json(new { action = "edit", removed = true, error = "" });
            }

            return Json(new { action = "edit", removed = false, error = "Ce frais ne correspond pas au votre" });
        }

        public ActionResult GetProjectForCustomer(string projectIdForSelect)
        {
            return PartialView("_Project_ID", ProjectService.GetAllByCustomer(projectIdForSelect));
        }
    }
}