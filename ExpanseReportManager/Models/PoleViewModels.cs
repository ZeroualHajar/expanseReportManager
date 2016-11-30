using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ExpanseReportManager.Models
{
    public class PoleViewModels
    {
        [Display(Name = "Id")]
        public String Id { get; set; }

        [Required()]
        [Display(Name = "Nom du pôle")]
        public string Name { get; set; }

        [Required()]
        [Display(Name = "Manager")]
        public Guid ManagerId { get; set; }

        [Display(Name = "Employees du pole")]
        public ICollection<EmployeeViewModels> PoleEmployees { get; set; }

        [Display(Name = "Manager du pole")]
        public EmployeeViewModels Manager { get; set; }

    }

    public class PoleCreateViewModels: PoleViewModels
    {
        [Display(Name="Liste des employees")]
        public ICollection<EmployeeViewModels> AllEmployees { get; set; }
    }
}

