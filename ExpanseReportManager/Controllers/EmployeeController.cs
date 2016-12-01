﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExpanseReportManager.Services;
using ExpanseReportManager.Models;

namespace ExpanseReportManager.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeService Service;

        public EmployeeController()
        {
            this.Service = new EmployeeService();
        }

        // GET: Employee
        public ActionResult Index()
        {
            IEnumerable<EmployeeViewModels> employees =  Service.GetAll();

            return View(employees);
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            Service.Delete(id);

            return RedirectToAction("Index", "Employee");
        }

        public ActionResult ByPole(string id)
        {
            IEnumerable<EmployeeViewModels> employees = Service.GetAllByPole(id);

            return View(employees);
        }

    }
}
