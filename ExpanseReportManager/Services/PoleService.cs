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
    public class PoleService
    {
        public PoleMapper Mapper;
        public PoleRepository Repository;

        public PoleService()
        {
            this.Mapper = new PoleMapper();
            this.Repository = new PoleRepository(new NotesDeFraisEntities());
        }

        public ICollection<PoleViewModels> GetAll()
        {
            ICollection<PoleViewModels> result = new List<PoleViewModels>();

            IQueryable<Pole> poles = Repository.GetAll();
            foreach(Pole res in poles)
            {  
                result.Add(Mapper.DataToModel(res)) ;
            }

            return result;
        }

        public ICollection<PoleViewModels> Search(string query)
        {
            ICollection<PoleViewModels> result = new List<PoleViewModels>();

            IQueryable<Pole> poles = Repository.Search(query);
            foreach (Pole res in poles)
            {
                result.Add(Mapper.DataToModel(res));
            }

            return result;
        }


        public PoleViewModels GetById(string id)
        {
            return Mapper.DataToModel(Repository.GetById(id));
        }

        public void Add(PoleViewModels model)
        {
            Pole pole = new Pole();
            pole.Pole_ID = Guid.NewGuid();

            Repository.Add(Mapper.ModelToData(pole, model));
            Repository.Save();
        }

        public void Edit(PoleViewModels model)
        {
            Pole pole = Repository.GetById(model.Id);

            pole = Mapper.ModelToData(pole, model);
            Repository.Save();
        }

        public void Delete(string id)
        {
            Repository.Delete(Repository.GetById(id));
            Repository.Save();
        }
    }
}

