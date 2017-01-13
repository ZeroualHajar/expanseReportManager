using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExpanseReportManager.Services;
using System.ComponentModel.DataAnnotations;

namespace ExpanseReportManager.Models
{
    public class UserViewModels :AbstractViewModels
    {
        private RoleService RoleService;
        private EmployeeService EmployeeService;

        public UserViewModels() : base()
        {
            RoleService = new RoleService(Entities);
            EmployeeService = new EmployeeService(Entities);
        }

        [Display(Name = "Id")]
        public string Id { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Email confirmé")]
        public bool EmailConfirmed { get; set; }

        [Display(Name = "Numéro de téléphone")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Numéro de téléphone confirmé")]
        public bool PhoneNumberConfirmed { get; set; }

        [Display(Name = "Erreur d'authentification")]
        public int AccessFailedCount { get; set; }

        [Display(Name = "Login")]
        public string UserName { get; set; }

        [Display(Name = "Employée")]
        public EmployeeViewModels Employees
        {
            get
            {
                return EmployeeService.GetByUserId(Id);
            }
        }

        [Display(Name = "Roles")]
        public ICollection<RoleViewModels> Roles {
            get
            {
                return RoleService.GetAllForUser(Id);
            }
        }
    
    }
}