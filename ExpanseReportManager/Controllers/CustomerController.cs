﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExpanseReportManager.Services;
using ExpanseReportManager.Models;

namespace ExpanseReportManager.Controllers
{
    public class CustomerController : Controller
    {
        CustomerService Service;
        
        public CustomerController()
        {
            this.Service = new CustomerService();
        } 
        
        // GET: Client
        public ActionResult Index()
        {
            ICollection<CustomerViewModel> clients = Service.GetAll();

            return View(clients);
        }


        [HttpPost]
        public ActionResult CreateEdit(CustomerViewModel model)
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
            CustomerViewModel client = new CustomerViewModel();

            return View(client);
        }


        public ActionResult Edit(string id)
        {
            CustomerViewModel customer = Service.GetById(id);
            return View("Create",customer);
        }

        public ActionResult Details(string id)
        {
            CustomerViewModel customer = Service.GetById(id);
            return View(customer);
        }

        public ActionResult Delete(string id)
        {
            Service.Delete(id);
            return RedirectToAction("index");
        }

        public ActionResult CustomerSearch(string query)
        {
            ICollection<CustomerViewModel> list;
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
