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

        [Display(Name = "Nom du pôle")]
        public string Name { get; set; }

        [Display(Name = "Manager id")]
        public Guid ManagerId { get; set; }


    }
}

