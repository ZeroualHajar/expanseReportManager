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
    public class ExpanseTypeService
    {
        private ExpanseTypeMapper Mapper;
        private ExpanseTypeRepository Repository;


        public ExpanseTypeService(NotesDeFraisEntities entities)
        {
            this.Mapper = new ExpanseTypeMapper();
            this.Repository = new ExpanseTypeRepository(entities);
        }

        public ICollection<ExpanseTypeViewModels> GetAll()
        {
            return Mapper.AllToModel(Repository.GetAll());
        }

        public ICollection<ExpanseTypeViewModels> GetAllByTva(string id)
        {
            return Mapper.AllToModel(Repository.GetAll().Where(e => e.Tva_ID.ToString() == id));
        }

        public ICollection<ExpanseTypeViewModels> Search(string query)
        {
            return Mapper.AllToModel(Repository.Search(query));
        }


        public ExpanseTypeViewModels GetById(string id)
        {
            return Mapper.DataToModel(Repository.GetById(id));
        }

        public void Add(ExpanseTypeViewModels model)
        {
            ExpanseType expanseType = new ExpanseType();
            expanseType.ExpenseType_ID = Guid.NewGuid();

            Repository.Add(Mapper.ModelToData(expanseType, model));
            Repository.Save();
        }

        public void Edit(ExpanseTypeViewModels model)
        {
            ExpanseType expanseType = Repository.GetById(model.Id);

            expanseType = Mapper.ModelToData(expanseType, model);
            Repository.Save();
        }

        public void Delete(string id)
        {
            Repository.Delete(Repository.GetById(id));
            Repository.Save();
        }

        public bool IsValid(ExpanseTypeViewModels model)
        {
            return !model.Fixed || (model.Fixed && model.Ceilling != null);
        }
    }
}