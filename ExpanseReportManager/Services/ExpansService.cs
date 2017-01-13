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
    public class ExpansService
    {
        private ExpansMapper Mapper;
        private ExpansRepository Repository;

        public ExpansService(NotesDeFraisEntities entities)
        {
            this.Mapper = new ExpansMapper();
            this.Repository = new ExpansRepository(entities);
            
        }

        public ExpansViewModels GetById(string id)
        {
            Expans expans = Repository.GetById(id);
            return expans == null ? null : Mapper.DataToModel(expans);
        }

        public ICollection<ExpansViewModels> GetAllByCustomer(string id)
        {
            return Mapper.AllToModel(Repository.GetAll().Where(e => e.Customer_ID.ToString() == id).OrderBy(e => e.Day).OrderBy(e => e.Day));
        }

        public ICollection<ExpansViewModels> GetAllByExpanseType(string id)
        {
            return Mapper.AllToModel(Repository.GetAll().Where(e => e.ExpanseType_ID.ToString() == id).OrderBy(e => e.Day));
        }

        internal double CheckAmount(ExpansViewModels model)
        {
            return model.ExpanseType.Ceilling != null ? model.Amount_HT - (double)model.ExpanseType.Ceilling : -1;
        }

        public ICollection<ExpansViewModels> GetAllByReport(string id)
        {
            return Mapper.AllToModel(Repository.GetAll().Where(e => e.ExpanseReport_ID.ToString() == id).OrderBy(e => e.Day));
        }

        public void Add(ExpansViewModels model)
        {
            Expans expans = new Expans();
            expans.Expanse_ID = Guid.NewGuid();

            Repository.Add(Mapper.ModelToData(expans, model));
            Repository.Save();
        }

        public void Edit(ExpansViewModels model)
        {
            Expans expans = Repository.GetById(model.Id);

            expans = Mapper.ModelToData(expans, model);
            Repository.Save();
        }

        public void Delete(string id)
        {
            Repository.Delete(Repository.GetById(id));
            Repository.Save();
        }
    }
}