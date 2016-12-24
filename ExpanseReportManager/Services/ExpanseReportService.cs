using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExpanseReportManagerModel;
using ExpanseReportManager.Models;

namespace ExpanseReportManager.Services
{
    public class ExpanseReportService
    {
        public ExpanseReportService(NotesDeFraisEntities entities)
        {

        }

        public ICollection<ExpanseReportViewModels> GetAllCreatedByEmployee(string Id)
        {
            return null;
        }

        public ICollection<ExpanseReportViewModels> GetAllUsingByEmployee(string Id)
        {
            return null;
        }
    }
}