using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExpanseReportManagerModel;
using ExpanseReportManager.Models;

namespace ExpanseReportManager.Mapper
{
    public class TvaMapper
    {
        public ICollection<TvaViewModels> AllToModel(IQueryable<Tva> tvas)
        {
            return tvas.Select(tva => new TvaViewModels
            {
                TVA_ID = tva.TVA_ID.ToString(),
                Name = tva.Name,
                Value = tva.Value
            }).ToList();
        }

        public TvaViewModels DataToModel(Tva tva)
        {
            return new TvaViewModels
            {
                TVA_ID = tva.TVA_ID.ToString(),
                Name = tva.Name,
                Value = tva.Value
            };
        }

        public Tva ModelToData(Tva tva, TvaViewModels model)
        {
            tva.Name = model.Name;
            tva.Value = (double) model.Value / 100;

            return tva;
        }
    }
}