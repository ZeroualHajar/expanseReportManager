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
        public TvaViewModels DataToModel(Tva tva)
        {
            TvaViewModels result = new TvaViewModels()
            {

                TVA_ID = tva.TVA_ID.ToString(),
                Name = tva.Name,
                Value = tva.Value
            };

            return result;
        }

        public Tva ModelToData(Tva tva, TvaViewModels model)
        {
            tva.Name = model.Name;
            tva.Value = model.Value;

            return tva;
        }
    }
}