using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExpanseReportManager.Services;
using System.ComponentModel.DataAnnotations;

namespace ExpanseReportManager.Models
{
    public class ExpansViewModels : AbstractViewModels
    {
        private ExpanseTypeService ExpanseTypeService;
        private ExpanseReportService ExpanseReportService;
        private CustomerService CustomerService;
        private ProjectService ProjectService;

        public ExpansViewModels() : base()
        {
            ExpanseTypeService = new ExpanseTypeService(Entities);
            ExpanseReportService = new ExpanseReportService(Entities);
            CustomerService = new CustomerService(Entities);
            ProjectService = new ProjectService(Entities);
        }
        
        [Display(Name = "Id")]
        public string Id { get; set; }

        [Display(Name = "Note de frais")]
        [Required]
        public string ExpanseReport_ID { get; set; }

        [Display(Name = "Date du jour")]
        [Required]
        public int Day { get; set; }

        [Display(Name = "Type de frais")]
        [Required]
        public string ExpanseType_ID { get; set; }

        [Display(Name = "Client")]
        [Required]
        public string Customer_ID { get; set; }

        [Display(Name = "Projet")]
        [Required]
        public string Project_ID { get; set; }

        [Display(Name = "Coût HT")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [Required]
        public double Amount_HT { get; set; }

        [Display(Name = "Coût TVA")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Amount_TVA
        {
            get
            {
                return Amount_HT * (double) ExpanseType.Tva.Value;
            }
        }

        [Display(Name = "Coût Hors TTC")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Amount_TTC
        {
            get
            {
                return Amount_HT + Amount_TVA;
            }
        }

        [Display(Name = "Client")]
        public CustomerViewModels Customer
        {
            get
            {
                return CustomerService.GetById(Customer_ID);
            }
        }

        [Display(Name = "Note de frais")]
        public ExpanseReportViewModels ExpanseReport
        {
            get
            {
                return ExpanseReportService.GetById(ExpanseReport_ID);
            }
        }

        [Display(Name = "Type de frais")]
        public ExpanseTypeViewModels ExpanseType
        {
            get
            {
                return ExpanseTypeService.GetById(ExpanseType_ID);
            }
        }

        [Display(Name = "liste Type de frais")]
        public ICollection<ExpanseTypeViewModels> AllExpanseType
        {
            get
            {
                return ExpanseTypeService.GetAll();
            }
        }

        [Display(Name = "liste Type de frais")]
        public ICollection<ExpanseTypeViewModels> AllExpanseTypeForEmployee
        {
            get
            {
                return ExpanseTypeService.GetAllForEmployee();
            }
        }

        [Display(Name = "Liste Client")]
        public ICollection<CustomerViewModels> AllCustomer
        {
            get
            {
                return CustomerService.GetAll();
            }
        }

        [Display(Name = "Projet")]
        public ProjectViewModels Project
        {
            get
            {
                return ProjectService.GetById(Project_ID);
            }
        }

    }
}