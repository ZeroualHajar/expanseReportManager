using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using ExpanseReportManagerModel;
using ExpanseReportManager.Services;

namespace ExpanseReportManager.Models
{
    public class CustomerViewModels : AbstractViewModels
    {
        private ExpansService ExpansService;
        private ProjectService ProjectService;

        public CustomerViewModels() : base()
        {
            this.ExpansService = new ExpansService(Entities);
            this.ProjectService = new ProjectService(Entities);
        }

        [Display(Name = "Id")]
        public string Id { get; set; }

        [Required]
        [Display(Name ="Nom du client")]
        public string Name { get; set; }

        [Required]
        [Display(Name ="Code du client")]
        public string Code { get; set; }

        public virtual ICollection<ExpansViewModels> Expanses {
            get
            {
                return ExpansService.GetAllByCustomer(Id);
            }
        }

        public virtual ICollection<ProjectViewModels> Projects
        {
            get
            {
                return ProjectService.GetAllByCustomer(Id);
            }
        }
    }
}
