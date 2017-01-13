using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExpanseReportManager.Models;
using ExpanseReportManagerModel;

namespace ExpanseReportManager.Mapper
{
    public class ExpansMapper
    {
        public ICollection<ExpansViewModels> AllToModel(IQueryable<Expans> expanses)
        {
            return expanses.Select(expans => new ExpansViewModels
            {
                Id = expans.Expanse_ID.ToString(),
                Project_ID = expans.Project_ID.ToString(),
                ExpanseType_ID = expans.ExpanseType_ID.ToString(),
                ExpanseReport_ID = expans.ExpanseReport_ID.ToString(),
                Amount_HT = expans.Amount_HT,
                Customer_ID = expans.Customer_ID.ToString(),
                Day = expans.Day

            }).ToList();
        }

        public ExpansViewModels DataToModel(Expans expans)
        {
            return new ExpansViewModels
            {
                Id = expans.Expanse_ID.ToString(),
                Project_ID = expans.Project_ID.ToString(),
                ExpanseType_ID = expans.ExpanseType_ID.ToString(),
                ExpanseReport_ID = expans.ExpanseReport_ID.ToString(),
                Amount_HT = expans.Amount_HT,
                Customer_ID = expans.Customer_ID.ToString(),
                Day = expans.Day
            };
        }

        public Expans ModelToData(Expans expans, ExpansViewModels model)
        {
            expans.Project_ID = new Guid(model.Project_ID.ToString());
            expans.ExpanseType_ID = new Guid(model.ExpanseType_ID.ToString());
            expans.ExpanseReport_ID = new Guid(model.ExpanseReport_ID.ToString());
            expans.Amount_HT = model.Amount_HT;
            expans.Amount_TTC = model.Amount_TTC;
            expans.Amount_TVA = model.Amount_TVA;
            expans.Customer_ID = new Guid(model.Customer_ID.ToString());
            expans.Day = model.Day;

            return expans;
        }
    }
}