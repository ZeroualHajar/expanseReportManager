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
            ICollection<PoleViewModels> list = Service.GetAll();

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
            ICollection<PoleViewModels> list;
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
        public ActionResult EmployeeSearch(string poleId, string query)
        {
            ICollection<EmployeeViewModels> list;
            if (string.IsNullOrEmpty(query))
            {
                list = EmployeeService.GetAllByPole(poleId);
            }
            else
            {
                list = EmployeeService.SearchByPole(poleId, query);
            }

            return PartialView("_TableListManageEmployee", list);
        }


        public ActionResult ManageEmployees(string id)
        {
            ManagePoleEmployee managePole = new ManagePoleEmployee();
            managePole.Id = id;
            managePole.FreeEmployees = EmployeeService.GetAllFree();
            managePole.PoleEmployees = EmployeeService.GetAllByPole(id);

            return View(managePole);
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

        public ActionResult AddToPole(string poleId, string employeeId)
        {
            EmployeeService.AddToPole(poleId, employeeId);

            return RedirectToAction("ManageEmployees", "Pole", new { id = poleId });
        }

        public ActionResult RemoveFromPole(string poleId, string employeeId)
        {
            EmployeeService.RemoveFromPole(poleId, employeeId);

            return RedirectToAction("ManageEmployees",  "Pole", new { id = poleId });
        }


    }
}

