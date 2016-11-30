using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExpanseReportManager.Services;
using ExpanseReportManager.Models;
using ExpanseReportManager.Repositories;
using ExpanseReportManager.Mapper;

namespace ExpanseReportManager.Controllers
{
    public class PoleController : Controller
    {
        private PoleService Service;
        private EmployeeService EmployeeService; 

        public PoleController()
        {
            this.Service = new PoleService();
            this.EmployeeService = new EmployeeService();
        } 

        // GET: Pole
        public ActionResult Index()
        {
            List<PoleViewModels> list = Service.GetAll();

            return View(list);
        }

        public ActionResult Create()
        {
            PoleCreateViewModels pole = new PoleCreateViewModels();
            pole.AllEmployees = EmployeeService.GetAll();

            return View(pole);
        }

        [HttpPost]
        public ActionResult Create(PoleCreateViewModels model)
        {
            if (ModelState.IsValid)
            {
                Service.Add(model);

                return RedirectToAction("Create", model);
            }

            return View(model);
        }

        public ActionResult PoleSearch(string query)
        {
            List<PoleViewModels> list;
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

