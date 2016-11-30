using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExpanseReportManager.Services;

namespace ExpanseReportManager.Controllers
{
    public class ClientController : Controller
    {
        ClientService Service;
        
        public ClientController()
        {
            this.Service = new ClientService();
        } 
        
        // GET: Client
        public ActionResult Index()
        {

            return View();
        }


    }
}