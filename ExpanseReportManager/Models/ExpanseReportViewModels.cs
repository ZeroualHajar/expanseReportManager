using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExpanseReportManager.Services;
using System.ComponentModel.DataAnnotations;

namespace ExpanseReportManager.Models
{
    public class ExpanseReportViewModels : AbstractViewModels
    {
        protected ExpansService ExpansService;
        protected EmployeeService EmployeeService;

        public ExpanseReportViewModels() : base()
        {
            ExpansService = new ExpansService(Entities);
            EmployeeService = new EmployeeService(Entities);
        }

        [Display(Name ="Id note de frais")]
        public string ExpanseReport_ID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Vous devez selectionnez un employé")]
        [Display(Name = "Id de l'employée")]
        public string Employee_ID { get; set; }

        [Required]
        [Display(Name = "Id de l'auteur")]
        public string Author_ID { get; set; }

        [Required]
        [Display(Name = "Date de création")]
        public System.DateTime CreationDate { get; set; }

        [Display(Name = "Année")]
        public int Year { get; set; }

        [Display(Name = "Mois")]
        public int Month { get; set; }

        [Display(Name = "Statut")]
        public int StatusCode { get; set; }

        [Display(Name = "Date de validation par le manager")]
        public Nullable<System.DateTime> ManagerValidationDate { get; set; }

        [Display(Name = "Date de validation comptabilité")]
        public Nullable<System.DateTime> AccountingValidatationDate { get; set; }

        [Display(Name = "Total HT")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Total_HT { get; set; }

        [Display(Name = "Total TVA")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Total_TVA { get; set; }

        [Display(Name = "Total TTC")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Total_TTC { get; set; }

        [Display(Name = "Commentaire manager")]
        public string ManagerComment { get; set; }

        [Display(Name = "Commentaire comptabilité")]
        public string AccountingComment { get; set; }

        [Display(Name = "Employée")]
        public EmployeeViewModels Employee
        {
            get
            {
                return EmployeeService.GetById(Employee_ID);
            }
        }

        [Display(Name = "Auteur")]
        public EmployeeViewModels Author
        {
            get
            {
                return EmployeeService.GetById(Author_ID);
            }
        }

        [Display(Name = "Frais")]
        public ICollection<ExpansViewModels> Expanses
        {
            get
            {
                return ExpansService.GetAllByReport(ExpanseReport_ID);
            }
        }
    }

    public class CreateExpanseReportViewModels : ExpanseReportViewModels
    {
        public CreateExpanseReportViewModels() : base()
        {
        }

        [Display(Name = "Employés du pole")]
        public ICollection<EmployeeViewModels> Employees
        {
            get
            {
                return EmployeeService.GetAllByPole(Author.PoleId);
            }
        }

        [Display(Name = "Mois/Année")]
        [Required]
        public DateTime DateReport { get; set; }
    }
}