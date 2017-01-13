using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExpanseReportManager.Models;
using ExpanseReportManagerModel;

namespace ExpanseReportManager.Mapper
{
    public class PoleMapper
    {
        public ICollection<PoleViewModels> AllToModel(IQueryable<Pole> poles)
        {
            return poles.Select(p => new PoleViewModels
            {
                Id = p.Pole_ID.ToString(),
                Name = p.Name,
                ManagerId = p.Manager_ID.ToString()
                
            }).ToList();
        }

        public PoleViewModels DataToModel(Pole pole)
        {
            return new PoleViewModels()
            {
                Id = pole.Pole_ID.ToString(),
                Name = pole.Name,
                ManagerId = pole.Manager_ID.ToString()
            };
        }

        public Pole ModelToData(Pole pole, PoleViewModels model)
        {
            pole.Name = model.Name;
            pole.Manager_ID = new Guid(model.ManagerId);
            return pole;
        }
    }
}

