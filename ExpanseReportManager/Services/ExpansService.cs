using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExpanseReportManagerModel;
using ExpanseReportManager.Models;

namespace ExpanseReportManager.Services
{
    public class ExpansService
    {
        public ExpansService(NotesDeFraisEntities entities)
        {
            
        }

        public ICollection<ExpansViewModels> GetAllByCustomer(string Id)
        {
            return null;
        }

        public ICollection<ExpansViewModels> GetAllByExpanseType(string Id)
        {
            return null;
        }

        public ICollection<ExpansViewModels> GetAllByReport(string Id)
        {
            return null;
        }
        

    }
}