using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExpanseReportManagerModel;

namespace ExpanseReportManager.Repositories
{
    public class TvaRepository
    {
        public NotesDeFraisEntities Entities;

        public TvaRepository(NotesDeFraisEntities Entities)
        {
            this.Entities = Entities;
        }

        public IQueryable<Tva> GetAll()
        {
            return Entities.Tvas;
        }

        public Tva GetById(string id)
        {
            return Entities.Tvas.FirstOrDefault(t => t.TVA_ID.ToString() == id);
        }

        public void Add(Tva tva)
        {
            Entities.Tvas.Add(tva);
        }

        public IQueryable<Tva> Search(string query)
        {
            return Entities.Tvas.Where(p => p.Name.ToUpper().Contains(query.ToUpper()));
        }

        public void Delete(string id)
        {

            Entities.Tvas.Remove(GetById(id));
        }

        public void Save()
        {
            Entities.SaveChanges();
        }
    }
}