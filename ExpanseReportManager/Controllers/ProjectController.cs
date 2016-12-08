using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExpanseReportManager.Services;
using ExpanseReportManager.Models;


namespace ExpanseReportManager.Controllers
{
    public class ProjectController : Controller
    {
        private ProjectService Service;
        private CustomerService CustomerService;
        private PoleService PoleService;

        public ProjectController()
        {
            this.Service = new ProjectService();
            this.CustomerService = new CustomerService();
            this.PoleService = new PoleService();
        }

        // GET: Project
        public ActionResult Index()
        {
            ICollection<ProjectViewModels> projects = Service.GetAll();

            return View(projects);
        }

        [HttpPost]
        public ActionResult CreateEdit(ProjectViewModels model)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(model.Project_ID))
                {
                    
                    Service.Add(model);
                }
                else
                {
                    Service.Edit(model);
                }

                return RedirectToAction("Index");
            }

            model.AllCustomers = CustomerService.GetAll();
            model.AllPoles = PoleService.GetAll();
            if (!string.IsNullOrEmpty(model.Customer_Id) && !string.IsNullOrEmpty(model.Pole_Id))
            {
                model.Customer = CustomerService.GetById(model.Customer_Id);
                model.Pole = PoleService.GetById(model.Pole_Id);
            }

            return View("Create", model);
        }

        public ActionResult Create()
        {
            ProjectViewModels project = new ProjectViewModels();

            project.AllCustomers = CustomerService.GetAll();
            project.AllPoles = PoleService.GetAll();

            return View(project);
        }

        public ActionResult Edit(string id)
        {
            ProjectViewModels project = Service.GetById(id);

            project.Customer = CustomerService.GetById(project.Customer_Id);
            project.Pole = PoleService.GetById(project.Pole_Id);
            project.AllCustomers = CustomerService.GetAll();
            project.AllPoles = PoleService.GetAll();

            return View("Create", project);
        }

        public ActionResult Details(string id)
        {
            ProjectViewModels project = Service.GetById(id);
            return View(project);
        }

        public ActionResult Delete(string id)
        {
            Service.Delete(id);
            return RedirectToAction("index");
        }

        public ActionResult ProjectSearch(string query)
        {
            ICollection<ProjectViewModels> list;
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