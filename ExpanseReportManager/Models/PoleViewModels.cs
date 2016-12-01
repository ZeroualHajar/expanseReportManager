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

        [Required(AllowEmptyStrings = false, ErrorMessage = "Vous devez selectionnez un manager")]
        [Display(Name = "Manager")]
        public string ManagerId { get; set; }

        [Display(Name = "Employees du pole")]
        public ICollection<EmployeeViewModels> PoleEmployees { get; set; }

        [Display(Name = "Manager du pole")]
        public EmployeeViewModels Manager { get; set; }

        [Display(Name = "Employés du pole")]
        public ICollection<EmployeeViewModels> AllEmployees { get; set; }

    }
}

