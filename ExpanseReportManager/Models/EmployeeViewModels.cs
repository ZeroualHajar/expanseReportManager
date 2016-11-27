using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ExpanseReportManager.Models
{
    public class EmployeeViewModels
    {
        public String Id { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
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