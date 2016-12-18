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

        public TvaService()
        {
            this.Repository = new TvaRepository(new NotesDeFraisEntities());
            this.Mapper = new TvaMapper();
        }

        public ICollection<TvaViewModels> GetAll()
        {
            ICollection<TvaViewModels> result = new List<TvaViewModels>();

            IQueryable<Tva> tvas = Repository.GetAll();

            foreach (Tva tva in tvas)
            {
                result.Add(Mapper.DataToModel(tva));
            }

            return result;
        }

        public TvaViewModels GetById(string id)
        {
            return Mapper.DataToModel(Repository.GetById(id));
        }

        public void Add(TvaViewModels model)
        {
            Tva tva = new Tva();
            tva = Mapper.ModelToData(tva, model);
            tva.TVA_ID = Guid.NewGuid();

            Repository.Add(tva);
            Repository.Save();
        }

        public List<TvaViewModels> Search(string query)
        {
            List<TvaViewModels> result = new List<TvaViewModels>();

            IQueryable<Tva> tvas = Repository.Search(query);
            foreach (Tva tva in tvas)
            {
                result.Add(Mapper.DataToModel(tva));
            }

            return result;
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