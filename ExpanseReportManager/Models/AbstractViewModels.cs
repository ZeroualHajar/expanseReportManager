using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExpanseReportManagerModel;

namespace ExpanseReportManager.Models
{
    public class AbstractViewModels
    {
        public NotesDeFraisEntities Entities;

        public AbstractViewModels()
        {
            this.Entities = new NotesDeFraisEntities();
        }
    }
}