using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExpanseReportManager.Models;
using ExpanseReportManagerModel;

namespace ExpanseReportManager.Mapper
{
    public class ExpanseReportMapper
    {
        public ICollection<ExpanseReportViewModels> AllToModel(IQueryable<ExpanseReport> expanseReports)
        {
            return expanseReports.Select(expanseReport => new ExpanseReportViewModels
            {
                ExpanseReport_ID = expanseReport.ExpanseReport_ID.ToString(),
                Employee_ID = expanseReport.Employee_ID.ToString(),
                Author_ID = expanseReport.Author_ID.ToString(),
                CreationDate = expanseReport.CreationDate,
                Year = expanseReport.Year,
                Month = expanseReport.Month,
                StatusCode = expanseReport.StatusCode,
                ManagerComment = expanseReport.ManagerComment,
                ManagerValidationDate = expanseReport.ManagerValidationDate,
                AccountingComment = expanseReport.AccountingComment,
                AccountingValidationDate = expanseReport.AccountingValidatationDate,
                Total_HT = expanseReport.Total_HT,
                Total_TTC = expanseReport.Total_TTC,
                Total_TVA = expanseReport.Total_TVA
            }).ToList();
        }

        public ExpanseReportViewModels DataToModel(ExpanseReport expanseReport)
        {
            ExpanseReportViewModels result = new ExpanseReportViewModels()
            {
                ExpanseReport_ID = expanseReport.ExpanseReport_ID.ToString(),
                Employee_ID = expanseReport.Employee_ID.ToString(),
                Author_ID = expanseReport.Author_ID.ToString(),
                CreationDate = expanseReport.CreationDate,
                Year = expanseReport.Year,
                Month = expanseReport.Month,
                StatusCode = expanseReport.StatusCode,
                ManagerComment = expanseReport.ManagerComment,
                ManagerValidationDate = expanseReport.ManagerValidationDate,
                AccountingComment = expanseReport.AccountingComment,
                AccountingValidationDate = expanseReport.AccountingValidatationDate,
                Total_HT = expanseReport.Total_HT,
                Total_TTC = expanseReport.Total_TTC,
                Total_TVA = expanseReport.Total_TVA
            };

            return result;
        }

        public ExpanseReport ModelToData(ExpanseReport expanseReport, ExpanseReportViewModels model)
        {
            expanseReport.Employee_ID = new Guid(model.Employee_ID);
            expanseReport.Author_ID = new Guid(model.Author_ID);
            expanseReport.CreationDate = model.CreationDate;
            expanseReport.Year = model.Year;
            expanseReport.Month = model.Month;
            expanseReport.StatusCode = model.StatusCode;
            expanseReport.ManagerComment = model.ManagerComment;
            expanseReport.ManagerValidationDate = model.ManagerValidationDate;
            expanseReport.AccountingComment = model.AccountingComment;
            expanseReport.AccountingValidatationDate = model.AccountingValidationDate;
            expanseReport.Total_HT = model.Total_HT;
            expanseReport.Total_TTC = model.Total_TTC;
            expanseReport.Total_TVA = model.Total_TVA;

            return expanseReport;
        }
    }
}