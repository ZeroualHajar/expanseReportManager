using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExpanseReportManager.Services;
using ExpanseReportManager.Models;

namespace ExpanseReportManager.Controllers
{
    public class EmployeeController : AbstractController
    {
        private EmployeeService Service;
        private RoleService RoleService;

        public EmployeeController() : base()
        {
            this.Service = new EmployeeService(this.Entities);
            this.RoleService = new RoleService(this.Entities);
        }

        // GET: Employee
        public ActionResult Index()
        {
            return View(Service.GetAll());
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            Service.Delete(id);

            return RedirectToAction("Index", "Employee");
        }

        public ActionResult Associate()
        {
            ViewBag.Roles = new SelectList(RoleService.GetAll(), "Id", "Name");
            ViewBag.Employees = new SelectList(Service.GetAll(), "Id", "Name");

            return View(new AddRoleToEmployeeViewModels());
        }

        [HttpPost]
        public ActionResult Associate(AddRoleToEmployeeViewModels model)
        {
            if (ModelState.IsValid)
            {
                Service.Associate(model);

                return RedirectToAction("Index");
            }

            return View("Associate", model);
        }
        public ActionResult ByPole(string id)
        {
            return View("Index", Service.GetAllByPole(id));
        }

        public ActionResult Details(string id)
        {
            return View(Service.GetById(id));
        }

    }
}
