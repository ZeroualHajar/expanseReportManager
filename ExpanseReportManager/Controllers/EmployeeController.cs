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

        public EmployeeController() : base()
        {
            this.Service = new EmployeeService(this.Entities);
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
