﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExpanseReportManager.Services;
using ExpanseReportManager.Models;

namespace ExpanseReportManager.Controllers
{
    [CustomAuthorize(Roles = "SuperAdmin, Ressource Humaine")]
    public class CustomerController : AbstractController
    {
        private CustomerService Service;
        
        public CustomerController() : base()
        {
            this.Service = new CustomerService(this.Entities);
        } 
        
        // GET: Client
        public ActionResult Index()
        {
            return View(Service.GetAll());
        }


        [HttpPost]
        public ActionResult CreateEdit(CustomerViewModels model)
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

        public ActionResult Create()
        {
            return View(new CustomerViewModels());
        }


        public ActionResult Edit(string id)
        {
            CustomerViewModels model = Service.GetById(id);
            if(model == null)
            {
                return new HttpStatusCodeResult(404);
            }

            return View("Create", model);
        }

        public ActionResult Details(string id)
        {
            CustomerViewModels model = Service.GetById(id);
            if (model == null)
            {
                return new HttpStatusCodeResult(404);
            }

            return View(Service.GetById(id));
        }

        public ActionResult Delete(string id)
        {
            Service.Delete(id);

            return RedirectToAction("index");
        }

        public ActionResult CustomerSearch(string query)
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
    }
}

