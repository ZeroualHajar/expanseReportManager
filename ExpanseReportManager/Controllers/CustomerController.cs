using System;
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
            ICollection<CustomerViewModel> clients = new List<CustomerViewModel>();
            clients = Service.GetAll();

            return View(clients);
        }


        [HttpPost]
        public ActionResult Create(CustomerViewModel client)
        {
            if (ModelState.IsValid)
            {
                Service.Add(client);
                return RedirectToAction("Index");
            }

            return View(client);
        }

        public ActionResult Create()
        {
            CustomerViewModel client = new CustomerViewModel();

            return View(client);
        }

        public ActionResult Edit(string id)
        {
            CustomerViewModel customer = Service.GetById(id);
            return View(customer);
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


    }
}

