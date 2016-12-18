using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ExpanseReportManager.Models
{
    public class TvaViewModels
    {
       
        [Display (Name = "l'id de la TVA")]
        public string TVA_ID { get; set; }

        [Required]
        [Display(Name = "Nom")]
        public string Name { get; set; }

        [Required]
        [Range(0, 100, ErrorMessage = "La valeur de la {0} doit être comprise entre {1} et {2}")]
        [Display(Name ="TVA")]
        public Nullable<double> Value { get; set; }

        [Display(Name = "La liste de la TVA")]
        public ICollection<ExpanseTypeViewModels> ExpanseTypes;
    }
}