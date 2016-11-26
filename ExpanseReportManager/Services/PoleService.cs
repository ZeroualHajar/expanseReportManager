using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using ExpanseReportManagerModel;
using ExpanseReportManager.Mapping;
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

        public List<PoleViewModels> GetAll()
        {
            List<PoleViewModels> result = new List<PoleViewModels>();

            IQueryable<Pole> poles = Repository.GetAll();
            foreach(Pole res in poles)
            {  
                result.Add(Mapper.DataToModel(res)) ;
            }

            return result;
        }
    }
}

