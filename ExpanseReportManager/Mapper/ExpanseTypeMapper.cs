using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExpanseReportManager.Models;
using ExpanseReportManagerModel;

namespace ExpanseReportManager.Mapper
{
    public class ExpanseTypeMapper
    {
        public ExpanseTypeViewModels DataToModel(ExpanseType expanseType)
        {
            ExpanseTypeViewModels result = new ExpanseTypeViewModels()
            {
                Id = expanseType.ExpenseType_ID.ToString(),
                Name = expanseType.Name,
                OnlyManager = expanseType.OnlyManagers,
                Tva_Id = expanseType.Tva_ID.ToString(),
                Ceilling = expanseType.Ceiling,
                Fixed = expanseType.Fixed
            };

            return result;
        }

        public ExpanseType ModelToData(ExpanseType expanseType, ExpanseTypeViewModels model)
        {
            expanseType.Name = model.Name;
            expanseType.OnlyManagers = model.OnlyManager;
            expanseType.Tva_ID = new Guid(model.Tva_Id);
            expanseType.Ceiling = model.Ceilling;
            expanseType.Fixed = model.Fixed;

            return expanseType;
        }
    }
}