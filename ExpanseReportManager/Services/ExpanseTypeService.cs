﻿using System;
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
        private EmployeeService EmployeeService;


        public ExpanseTypeService()
        {
            this.Mapper = new ExpanseTypeMapper();
            this.Repository = new ExpanseTypeRepository(new NotesDeFraisEntities());
            this.EmployeeService = new EmployeeService();
        }

        public ICollection<ExpanseTypeViewModels> GetAll()
        {
            ICollection<ExpanseTypeViewModels> result = new List<ExpanseTypeViewModels>();

            IQueryable<ExpanseType> expanseTypes = Repository.GetAll();
            foreach (ExpanseType res in expanseTypes)
            {
                result.Add(Mapper.DataToModel(res));
            }

            return result;
        }

        public ICollection<ExpanseTypeViewModels> Search(string query)
        {
            ICollection<ExpanseTypeViewModels> result = new List<ExpanseTypeViewModels>();

            IQueryable<ExpanseType> expanseTypes = Repository.Search(query);
            foreach (ExpanseType res in expanseTypes)
            {
                result.Add(Mapper.DataToModel(res));
            }

            return result;
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