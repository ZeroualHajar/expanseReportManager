using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ExpanseReportManager.Models
{
    public class ExpanseTypeViewModels
    {
        [Display(Name = "L'identifiant du type de frais")]
        public string Id { get; set; }

        [Required]
        [Display(Name = "Nom")]
        public string Name { get; set; }

        [Display(Name = "Plafond")]
        public Nullable<double> Ceilling { get; set; }

        [Required]
        [Display(Name = "Fixé")]
        public bool Fixed { get; set; }

        [Required]
        [Display(Name = "Pour manager uniquement")]
        public bool OnlyManager { get; set; }

        [Required]
        [Display(Name = "TVA")]
        public string Tva_Id { get; set; }

        [Display(Name = "TVA")]
        public TvaViewModels Tva { get; set; }
    }
}