using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExpanseReportManager.Services;
using System.ComponentModel.DataAnnotations;

namespace ExpanseReportManager.Models
{
    public class EmployeeViewModels : AbstractViewModels
    {
        private ExpanseReportService ExpanseReportService;
        private PoleService PoleService;

        public EmployeeViewModels() : base()
        {
            ExpanseReportService = new ExpanseReportService(Entities);
            PoleService = new PoleService(Entities);
        }

        [Display(Name = "Id")]
        public string Id { get; set; }

        [Display(Name = "Id Utilisateur")]
        public string UserId { get; set; }

        [Display(Name = "Prénom")]
        public string FirstName { get; set; }

        [Display(Name = "Nom")]
        public string LastName { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Telephone")]
        public string Telephone { get; set; }

        [Display(Name = "ID Pole")]
        public string PoleId { get; set; }

        [Display(Name = "Pole de l'employé")]
        public PoleViewModels Pole
        {
            get
            {
                return PoleService.GetForEmployee(PoleId);
            }
        }

        [Display(Name = "Rapports de notes de frais créer")]
        public ICollection<ExpanseReportViewModels> CreatedExpanseReports
        {
            get
            {
                return ExpanseReportService.GetAllCreatedByEmployee(Id);
            }
        }

        [Display(Name = "Rapports de notes de frais utiliser")]
        public ICollection<ExpanseReportViewModels> UsingExpanseReports
        {
            get
            {
                return ExpanseReportService.GetAllUsingByEmployee(Id);
            }
        }

        [Display(Name = "Poles managé")]
        public ICollection<PoleViewModels> ManagedPoles
        {
            get
            {
                return PoleService.GetAllByManager(Id);
            }
        }

    }

}