using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExpanseReportManagerModel;
using ExpanseReportManager.Mapper;
using ExpanseReportManager.Models;
using ExpanseReportManager.Repositories;

namespace ExpanseReportManager.Services
{
    public class ExpanseReportService
    {
        private ExpanseReportMapper Mapper;
        private ExpanseReportRepository Repository;

        public ExpanseReportService(NotesDeFraisEntities entities)
        {
            this.Mapper = new ExpanseReportMapper();
            this.Repository = new ExpanseReportRepository(entities);
        }

        public ICollection<ExpanseReportViewModels> GetAll()
        {
            return Mapper.AllToModel(Repository.GetAll());
        }

        public ICollection<ExpanseReportViewModels> GetAllCreatedByEmployee(string id)
        {
            return Mapper.AllToModel(Repository.GetAll().Where(e => e.Author_ID.ToString() == id));
        }

        public ICollection<ExpanseReportViewModels> GetAllUsingByEmployee(string id)
        {
            return Mapper.AllToModel(Repository.GetAll().Where(e => e.Employee_ID.ToString() == id));
        }

        public ICollection<ExpanseReportViewModels> SearchForEmployee(string employeeId, string query)
        {
            return Mapper.AllToModel(Repository.SearchForEmployee(employeeId, query));
        }

        public ICollection<ExpanseReportViewModels> Search(string query)
        {
            return Mapper.AllToModel(Repository.Search(query));
        }

        public ExpanseReportViewModels GetById(string id)
        {
            return Mapper.DataToModel(Repository.GetById(id));
        }

        public void Add(ExpanseReportViewModels model)
        {
            ExpanseReport expanseReport = new ExpanseReport();
            expanseReport.ExpanseReport_ID = Guid.NewGuid();

            Repository.Add(Mapper.ModelToData(expanseReport, model));
            Repository.Save();
        }

        public void Edit(ExpanseReportViewModels model)
        {
            ExpanseReport expanseReport = Repository.GetById(model.ExpanseReport_ID);

            expanseReport = Mapper.ModelToData(expanseReport, model);
            Repository.Save();
        }

        public void Delete(string id)
        {
            Repository.Delete(Repository.GetById(id));
            Repository.Save();
        }
    }
}