using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ExpanseReportManager.Models
{
    public class ClientViewModel
    {

        [Display(Name = "")]
        public string Id { get; set; }

        [Display(Name ="Non du client")]
        public string Name { get; set; }

        [Display(Name ="Code du client")]
        public string Code { get; set; }

    }
}
