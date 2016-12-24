using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExpanseReportManager.Mapper;
using ExpanseReportManager.Repositories;
using ExpanseReportManagerModel;
using ExpanseReportManager.Models;

namespace ExpanseReportManager.Services
{
    public class TvaService
    {
        public TvaRepository Repository;
        public TvaMapper Mapper;

        public TvaService(NotesDeFraisEntities entities)
        {
            this.Repository = new TvaRepository(entities);
            this.Mapper = new TvaMapper();
        }

        public ICollection<TvaViewModels> GetAll()
        {
            return Mapper.AllToModel(Repository.GetAll());
        }

        public ICollection<TvaViewModels> GetAllByTva(string id)
        {
            return Mapper.AllToModel(Repository.GetAll().Where(t => t.TVA_ID.ToString() == id));
        }

        public TvaViewModels GetById(string id)
        {
            return Mapper.DataToModel(Repository.GetById(id));
        }

        public TvaViewModels GetForExpanseType(string id)
        {
            return Mapper.DataToModel(Repository.GetForExpanseType(id));
        }

        public void Add(TvaViewModels model)
        {
            Tva tva = new Tva();
            tva = Mapper.ModelToData(tva, model);
            tva.TVA_ID = Guid.NewGuid();

            Repository.Add(tva);
            Repository.Save();
        }

        public ICollection<TvaViewModels> Search(string query)
        {
            return Mapper.AllToModel(Repository.Search(query));
        }

        public void Delete(string id)
        {
            Repository.Delete(id);
            Repository.Save();
        }

        public void Edit(TvaViewModels model)
        {
            Tva tva = Repository.GetById(model.TVA_ID);
            tva = Mapper.ModelToData(tva, model);
            Repository.Save();
        }

    }
}