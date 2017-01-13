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
    public class PoleService
    {
        private PoleMapper Mapper;
        private PoleRepository Repository;


        public PoleService(NotesDeFraisEntities entities)
        {
            this.Mapper = new PoleMapper();
            this.Repository = new PoleRepository(entities);
        }

        public ICollection<PoleViewModels> GetAll()
        {
            return Mapper.AllToModel(Repository.GetAll());
        }

        public ICollection<PoleViewModels> GetAllByManager(string id)
        {
            return Mapper.AllToModel(Repository.GetAll().Where(p => p.Manager_ID.ToString() == id));
        }

        public PoleViewModels GetForEmployee(string id)
        {
            Pole pole = Repository.GetForEmployee(id);
            return pole == null ? null : Mapper.DataToModel(pole);
        }

        public ICollection<PoleViewModels> Search(string query)
        {
            return Mapper.AllToModel(Repository.Search(query));
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

