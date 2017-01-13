using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExpanseReportManagerModel;

namespace ExpanseReportManager.Repositories
{
    public class ExpansRepository
    {
        public NotesDeFraisEntities Entities;

        public ExpansRepository(NotesDeFraisEntities entities)
        {
            this.Entities = entities;
        }

        public IQueryable<Expans> GetAll()
        {
            return Entities.Expanses;
        }

        public Expans GetById(string id)
        {
            return Entities.Expanses.FirstOrDefault(c => c.Expanse_ID.ToString() == id);
        }

        public void Add(Expans expans)
        {
            Entities.Expanses.Add(expans);
        }

        public void Delete(Expans expans)
        {
            Entities.Expanses.Remove(expans);
        }

        public void Save()
        {
            Entities.SaveChanges();
        }
    }
}