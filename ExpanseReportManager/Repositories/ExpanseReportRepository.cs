using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExpanseReportManagerModel;

namespace ExpanseReportManager.Repositories
{
    public class ExpanseReportRepository
    {
        public NotesDeFraisEntities Entities;

        public ExpanseReportRepository(NotesDeFraisEntities entities)
        {
            this.Entities = entities;
        }

        public IQueryable<ExpanseReport> GetAll()
        {
            return Entities.ExpanseReports;
        }

        public IQueryable<ExpanseReport> Search(string query)
        {
            return null;
        }


        public ExpanseReport GetById(string id)
        {
            return GetAll().FirstOrDefault(e => e.ExpanseReport_ID.ToString() == id);
        }

        public void Add(ExpanseReport expanseReport)
        {
            Entities.ExpanseReports.Add(expanseReport);
        }

        public void Delete(ExpanseReport expanseReport)
        {
            Entities.ExpanseReports.Remove(expanseReport);
        }

        public void Save()
        {
            Entities.SaveChanges();
        }
    }
}