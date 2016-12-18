using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.Linq;
using System.Web;

namespace ExpanseReportManager.Models
{
    public class ProjectViewModels
    {
        [Display(Name = "l'id du projet")]
        public string Project_ID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Vous devez entrez un nom de projet")]
        [Display(Name = "Le nom du projet")]
        public string Name { get; set; }


        [Required]
        [Display(Name = "La description du projet")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        [Range(1, Double.MaxValue)]
        [Display(Name = "Le budget du projet")]
        public double Budget { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Vous devez selectionnez un client")]
        [Display(Name ="Le client du projet")]
        public string Customer_Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Vous devez selectionnez un pole")]
        [Display(Name = "Le pole du projet")]
        public string Pole_Id { get; set; }

        [Display(Name = " La liste des client ")]
        public ICollection<CustomerViewModel> AllCustomers { get; set; }

        [Display(Name = "La liste des poles")]
        public ICollection<PoleViewModels> AllPoles { get; set; }

        [Display(Name = "Le client de projet")]
        public CustomerViewModel Customer { get; set; }

        [Display(Name = "Le pole du projet")]
        public PoleViewModels Pole { get; set; }



    }
}