using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpanseReportManagerModel;

namespace ExpanceReportManagerRepository
{
    class TvaRepository
    {
        public NotesDeFraisEntities Entities;
        public TvaRepository(NotesDeFraisEntities entities)
        {
            this.Entities = entities;
        }

        public IQueryable<Tva> GetAll()
        {
            return Entities.Tvas;
        }

    }
}
