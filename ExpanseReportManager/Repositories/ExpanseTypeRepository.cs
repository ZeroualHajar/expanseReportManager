using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExpanseReportManagerModel;

namespace ExpanseReportManager.Repositories
{
    public class ExpanseTypeRepository
    {
        public NotesDeFraisEntities Entities;

        public ExpanseTypeRepository(NotesDeFraisEntities entities)
        {
            this.Entities = entities;
        }

        public IQueryable<ExpanseType> GetAll()
        {
            return Entities.ExpanseTypes;
        }

        public ExpanseType GetById(string id)
        {
            return Entities.ExpanseTypes.FirstOrDefault(e => e.ExpenseType_ID.ToString() == id);
        }

        public void Add(ExpanseType expanseType)
        {
            Entities.ExpanseTypes.Add(expanseType);
        }

        public IQueryable<ExpanseType> Search(string query)
        {
            return Entities.ExpanseTypes.Where(e => e.Name.ToUpper().Contains(query.ToUpper()));
        }

        public void Delete(ExpanseType expanseType)
        {
            Entities.ExpanseTypes.Remove(expanseType);
        }

        public void Save()
        {
            Entities.SaveChanges();
        }
    }
}