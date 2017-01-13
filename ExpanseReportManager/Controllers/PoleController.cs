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
    [CustomAuthorize(Roles = "SuperAdmin, Ressource Humaine")]
    public class PoleController : AbstractController
    {
        private PoleService Service;
        private EmployeeService EmployeeService;

        public PoleController() : base()
        {
            this.Service = new PoleService(this.Entities);
            this.EmployeeService = new EmployeeService(this.Entities);
        } 

        // GET: Pole
        public ActionResult Index()
        {
            return View(Service.GetAll());
        }

        public ActionResult Create()
        {
            return View(new PoleViewModels());
        }

        public ActionResult Edit(string id)
        {
            PoleViewModels model = Service.GetById(id);
            if (model == null)
            {
                return new HttpStatusCodeResult(404);
            }

            return View("Create", model);
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

            return View("Create", model);
        }

        public ActionResult PoleSearch(string query)
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

        public ActionResult EmployeeSearch(string poleId, string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                return PartialView("_TableListManageEmployee", EmployeeService.GetAllByPole(poleId));
            }
            else
            {
                return PartialView("_TableListManageEmployee", EmployeeService.SearchByPole(poleId, query));
            }
        }


        public ActionResult ManageEmployees(string id)
        {
            return View(Service.GetById(id));
        }

        public ActionResult Details(string id)
        {
            PoleViewModels model = Service.GetById(id);
            if (model == null)
            {
                return new HttpStatusCodeResult(404);
            }

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

