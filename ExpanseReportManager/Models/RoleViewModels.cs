using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ExpanseReportManager.Models
{
    public class RoleViewModels
    {
        [Display(Name = "Id Role")]
        public string Id { get; set; }

        [Display(Name = "Nom Role")]
        [Required]
        [MinLength(2)]
        public string Name { get; set; }

        [Display(Name = "Liste des employees")]
        public ICollection<EmployeeViewModels> Employees { get; set; }
    }

    public class RoleIndexModel
    {
        [Display(Name = "Nouveau role")]
        public RoleViewModels NewRole { get; set; }

        [Display(Name = "Liste des roles")]
        public ICollection<RoleViewModels> Roles { get; set; }

    }

}
