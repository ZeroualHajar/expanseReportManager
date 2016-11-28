using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ExpanseReportManager.Models
{
    public class EmployeeViewModels
    {
        [Display(Name = "Id")]
        public String Id { get; set; }

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
        public Nullable<Guid> PoleId { get; set; }

        [Display(Name = "Pole de l'employé")]
        public virtual PoleViewModels Pole { get; set; }

        [Display(Name = "Rapports de notes de frais créer")]
        public virtual ICollection<ExpanseReportViewModels> CreatedExpanseReports { get; set; }

        [Display(Name = "Rapports de notes de frais utiliser")]
        public virtual ICollection<ExpanseReportViewModels> UsingExpanseReports { get; set; }

        [Display(Name = "Poles managé")]
        public virtual ICollection<PoleViewModels> ManagedPoles { get; set; }

    }
}