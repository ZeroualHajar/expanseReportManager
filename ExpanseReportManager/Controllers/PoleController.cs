using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExpanseReportManager.Services;
using ExpanseReportManager.Models;
using ExpanseReportManager.Repositories;
using ExpanseReportManager.Mapping;

namespace ExpanseReportManager.Controllers
{
    public class PoleController : Controller
    {
        public PoleService PoleService;

        public PoleController()
        {
            this.PoleService = new PoleService();
        } 
        // GET: Pole
        public ActionResult Index()
        {
            List<PoleViewModels> list = PoleService.GetAll();
            return View(list);
        }
    }
}

