using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ExpanseReportManager.Models
{
    public class ExpanseTypeViewModels
    {

        [Required]
        [Display(Name = "L'identifiant de expanse type")]
        public string Id;

        [Required]
        [Display(Name = "Le nom de expanse type")]
        public string Name;


        [Required]
        [Display(Name = "Le plafond")]
        public double Ceilling;


        [Required]
        [Display(Name = "Fixé")]
        public bool Fixed;


        [Required]
        [Display(Name = "Juste Manager")]
        public bool OnlyManager;

        [Required]
        [Display(Name = "L'id TVA")]
        public string Tva_Id;

        [Display(Name = "Le TVA")]
        public TvaViewModels Tva;
    }
}