using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExpanseReportManagerModel;

namespace ExpanseReportManager.Controllers
{
    public class AbstractController : Controller
    {
        public NotesDeFraisEntities Entities;

        public AbstractController()
        {
            this.Entities = new NotesDeFraisEntities();
        }
    }
}