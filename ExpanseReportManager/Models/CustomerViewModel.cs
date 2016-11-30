using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ExpanseReportManager.Models
{
    public class CustomerViewModel
    {

        [Display(Name = "")]
        public string Id { get; set; }

        [Required]
        [Display(Name ="Nom du client")]
        public string Name { get; set; }

        [Required]
        [Display(Name ="Code du client")]
        public string Code { get; set; }

    }
}
