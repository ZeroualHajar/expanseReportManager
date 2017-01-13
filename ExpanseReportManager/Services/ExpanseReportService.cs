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
            return Mapper.AllToModel(Repository.GetAll().OrderBy(e => e.Year).ThenBy(e => e.Month));
        }

        public ICollection<ExpanseReportViewModels> GetAllCreatedByEmployee(string id)
        {
            return Mapper.AllToModel(Repository.GetAll().Where(e => e.Author_ID.ToString() == id).OrderBy(e => e.Year).ThenBy(e => e.Month));
        }

        public ICollection<ExpanseReportViewModels> GetAllUsingByEmployee(string id)
        {
            return Mapper.AllToModel(Repository.GetAll().Where(e => e.Employee_ID.ToString() == id).OrderBy(e => e.Year).ThenBy(e => e.Month));
        }

        public ICollection<ExpanseReportViewModels> SearchForEmployee(string employeeId, string query)
        {
            return Mapper.AllToModel(Repository.SearchForEmployee(employeeId, query).OrderBy(e => e.Year).ThenBy(e => e.Month));
        }

        public ICollection<ExpanseReportViewModels> Search(string query)
        {
            return Mapper.AllToModel(Repository.Search(query).OrderBy(e => e.Year).ThenBy(e => e.Month));
        }

        public void UpdateAmount(string id)
        {
            ExpanseReport report = Repository.GetById(id);
            report.Total_HT = report.Expanses.Sum(e => e.Amount_HT);
            report.Total_TVA = report.Expanses.Sum(e => e.Amount_TVA);
            report.Total_TTC = report.Expanses.Sum(e => e.Amount_TTC);

            Repository.Save();
        }

        public ExpanseReportViewModels GetById(string id)
        {
            ExpanseReport expanseReport = Repository.GetById(id);
            return expanseReport == null ? null : Mapper.DataToModel(expanseReport);
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

        public ICollection<ExpanseReportViewModels> GetAllToValidateManager(string id)
        {
            return Mapper.AllToModel(Repository.GetAll().Where(e => 
                e.StatusCode == ExpanseReportViewModels.STATUS_WAITING_FOR_MANAGER &&
                e.Employee.Pole.Manager_ID.ToString() == id
            ).OrderBy(e => e.Year).ThenBy(e => e.Month));
        }

        public ICollection<ExpanseReportViewModels> GetAllToValidateAcounting()
        {
            return Mapper.AllToModel(Repository.GetAll().Where(e =>
                e.StatusCode == ExpanseReportViewModels.STATUS_WAITING_FOR_ACCOUNTING
            ).OrderBy(e => e.Year).ThenBy(e => e.Month));
        }

        public bool CheckDay(ExpansViewModels model)
        {
            return GetById(model.ExpanseReport_ID).Days.Contains(model.Day) ;
        }
    }
}