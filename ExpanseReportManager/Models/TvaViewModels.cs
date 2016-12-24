using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExpanseReportManager.Services;
using System.ComponentModel.DataAnnotations;

namespace ExpanseReportManager.Models
{
    public class TvaViewModels : AbstractViewModels
    {
        private ExpanseTypeService ExpanseTypeService;

        public TvaViewModels() : base()
        {
            ExpanseTypeService = new ExpanseTypeService(Entities);
        }

        [Display (Name = "l'id de la TVA")]
        public string TVA_ID { get; set; }

        [Required]
        [Display(Name = "Nom")]
        public string Name { get; set; }

        [Required]
        [Range(0, 100, ErrorMessage = "La valeur de la {0} doit être comprise entre {1} et {2}")]
        [DisplayFormat(DataFormatString = "{0:P2}")]
        [Display(Name ="Valeur")]
        public Nullable<double> Value { get; set; }

        [Display(Name = "La liste de la TVA")]
        public ICollection<ExpanseTypeViewModels> ExpanseTypes
        {
            get
            {
                return ExpanseTypeService.GetAllByTva(TVA_ID);
            }
        }
    }
}