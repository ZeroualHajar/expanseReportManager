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
        public Guid Id { get; set; }

        [Required()]
        [Display(Name = "Nom du pôle")]
        public string Name { get; set; }

        [Required()]
        [Display(Name = "Manager id")]
        public Guid ManagerId { get; set; }


    }
}

