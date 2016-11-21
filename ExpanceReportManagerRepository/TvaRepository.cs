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
        public NotesDeFraisEntities entities;
        public TvaRepository(NotesDeFraisEntities entities)
        {
            this.entities = entities;
        }

        public IQueryable<Tva> getAll()
        {
            return entities.Tvas;
        }

    }
}
