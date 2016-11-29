using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExpanseReportManager.Models;
using ExpanseReportManager.Services;

namespace ExpanseReportManager.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class RoleController : Controller
    {
        RoleService Service;
        public RoleController()
        {
            this.Service = new RoleService();
        }

        // GET: Role
        public ActionResult Index()
        {
            RoleIndexModel role = new RoleIndexModel();
            role.Roles = Service.GetAll();
            role.NewRole = new RoleViewModels();

            return View(role);
        }

        public ActionResult Create(RoleIndexModel model)
        {
            if (ModelState.IsValid)
            {
                Service.Add(model.NewRole);
            }
            
            return RedirectToAction("index", "Role");
        }

        public ActionResult Edit(string id)
        {
            RoleViewModels role = Service.GetById(id);
            return View(role);
        }

        public ActionResult Delete(string id)
        {
            Service.Delete(id);
            return RedirectToAction("index", "Role");
        }
    }


}
