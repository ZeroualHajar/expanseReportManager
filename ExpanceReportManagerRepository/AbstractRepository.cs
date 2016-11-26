using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpanseReportManagerModel;

namespace ExpanceReportManagerRepository
{
    class AbstractRepository
    {
        NotesDeFraisEntities Entities;

        public AbstractRepository(NotesDeFraisEntities entities)
        {
            Entities = entities;
        }
    }
}
