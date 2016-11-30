using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExpanseReportManagerModel;

namespace ExpanseReportManager.Repositories
{
    public class PoleRepository
    {
        public NotesDeFraisEntities entities;
        public PoleRepository(NotesDeFraisEntities entities)
        {
            this.entities = entities;
        }

        public IQueryable<Pole> GetAll()
        {
            return entities.Poles;
        }
        public IQueryable<Pole> Search(string query)
        {
            return entities.Poles.Where(
                p => p.Name.ToUpper().Contains(query.ToUpper()) ||
                    p.Employee.FirstName.ToUpper().Contains(query.ToUpper()) ||
                    p.Employee.LastName.ToUpper().Contains(query.ToUpper())
            );
        }


        public Pole GetById(string id)
        {
            return GetAll().FirstOrDefault(p => p.Pole_ID.ToString() == id);
        }

        public void Add(Pole pole)
        {
            entities.Poles.Add(pole);
        }

        public void Delete(Pole pole)
        {
            entities.Poles.Remove(pole);
        }

        public void Save()
        {
            entities.SaveChanges();
        }
    }
}
