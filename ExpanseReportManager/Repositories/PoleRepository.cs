using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExpanseReportManagerModel;

namespace ExpanseReportManager.Repositories
{
    public class PoleRepository
    {
        public NotesDeFraisEntities Entities;
        public PoleRepository(NotesDeFraisEntities entities)
        {
            this.Entities = entities;
        }

        public IQueryable<Pole> GetAll()
        {
            return Entities.Poles;
        }

        public IQueryable<Pole> Search(string query)
        {
            return Entities.Poles.Where(
                p => p.Name.ToUpper().Contains(query.ToUpper()) ||
                    p.Employee.FirstName.ToUpper().Contains(query.ToUpper()) ||
                    p.Employee.LastName.ToUpper().Contains(query.ToUpper())
            );
        }


        public Pole GetById(string id)
        {
            return GetAll().FirstOrDefault(p => p.Pole_ID.ToString() == id);
        }

        public Pole GetForEmployee(string id)
        {
            return Entities.Employees.FirstOrDefault(e => e.Employee_ID.ToString() == id) == null ? null : Entities.Employees.FirstOrDefault(e => e.Employee_ID.ToString() == id).Pole;
        }

        public void Add(Pole pole)
        {
            Entities.Poles.Add(pole);
        }

        public void Delete(Pole pole)
        {
            Entities.Poles.Remove(pole);
        }

        public void Save()
        {
            Entities.SaveChanges();
        }
    }
}
