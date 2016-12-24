using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExpanseReportManager.Services;
using System.ComponentModel.DataAnnotations;

namespace ExpanseReportManager.Models
{
    public class PoleViewModels : AbstractViewModels
    {
        private ProjectService ProjectService;
        private EmployeeService EmployeeService;

        public PoleViewModels() : base()
        {
            ProjectService = new ProjectService(Entities);
            EmployeeService = new EmployeeService(Entities);
        }

        [Display(Name = "Id")]
        public String Id { get; set; }

        [Required()]
        [Display(Name = "Nom du pôle")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Vous devez selectionnez un manager")]
        [Display(Name = "Manager")]
        public string ManagerId { get; set; }

        [Display(Name = "Employees du pole")]
        public ICollection<EmployeeViewModels> PoleEmployees
        {
            get
            {
                return EmployeeService.GetAllByPole(Id);
            }
        }

        [Display(Name = "Projets du pole")]
        public ICollection<ProjectViewModels> PoleProjects
        {
            get
            {
                return ProjectService.GetAllByPole(Id);
            }
        }

        [Display(Name = "Manager du pole")]
        public EmployeeViewModels Manager
        {
            get
            {
                return EmployeeService.GetById(ManagerId);
            }
        }

        [Display(Name = "Tous les employées")]
        public ICollection<EmployeeViewModels> AllEmployees
        {
            get
            {
                return EmployeeService.GetAll();
            }
        }

        [Display(Name = "Employé libre")]
        public ICollection<EmployeeViewModels> FreeEmployees
        {
            get
            {
                return EmployeeService.GetAllFree();
            }
        }

    }
}

