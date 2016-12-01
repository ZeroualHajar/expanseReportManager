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
            PoleViewModels pole = new PoleViewModels();

            pole.AllEmployees = EmployeeService.GetAll();

            return View(pole);
        }

        public ActionResult Edit(string id)
        {
            PoleViewModels pole = Service.GetById(id);

            pole.AllEmployees = EmployeeService.GetAll();

            return View("Create", pole);
        }

        [HttpPost]
        public ActionResult CreateEdit(PoleViewModels model)
        {
            if (ModelState.IsValid)
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

            model.AllEmployees = EmployeeService.GetAll();
            if (!string.IsNullOrEmpty(model.ManagerId))
            {
                model.Manager = EmployeeService.GetById(model.ManagerId);
            }

            return View("Create", model);
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

        public ActionResult Details(string id)
        {
            PoleViewModels model = Service.GetById(id);
            model.PoleEmployees = EmployeeService.GetAllByPole(id);
            model.Manager = EmployeeService.GetById(model.ManagerId);

            return View(model);
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            Service.Delete(id);

            return RedirectToAction("Index");
        }

    }
}

