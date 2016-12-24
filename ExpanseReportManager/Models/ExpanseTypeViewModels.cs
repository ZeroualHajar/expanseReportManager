using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExpanseReportManager.Services;
using System.ComponentModel.DataAnnotations;

namespace ExpanseReportManager.Models
{
    public class ExpanseTypeViewModels : AbstractViewModels
    {
        private TvaService TvaService;
        private ExpansService ExpansService;

        public ExpanseTypeViewModels() : base()
        {
            ExpansService = new ExpansService(Entities);
            TvaService = new TvaService(Entities);
        }

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
        public TvaViewModels Tva
        {
            get
            {
                return TvaService.GetForExpanseType(Id);
            } 
        }

        public ICollection<ExpansViewModels> Expanses
        {
            get
            {
                return ExpansService.GetAllByExpanseType(Id);
            }
        }
    }
}