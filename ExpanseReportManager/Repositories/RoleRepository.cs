using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExpanseReportManagerModel;

namespace ExpanseReportManager.Repositories
{
    public class RoleRepository
    {
        public NotesDeFraisEntities Entities;
        public RoleRepository(NotesDeFraisEntities entities)
        {
            this.Entities = entities;
        }

        public IQueryable<AspNetRole> GetAll()
        {
            return Entities.AspNetRoles.Where(r => r.Name != "SuperAdmin");
        }

        public IQueryable<AspNetRole> GetAllForUser(string id)
        {
            return Entities.AspNetUsers.FirstOrDefault(u => u.Id == id) != null ? 
                Entities.AspNetUsers.FirstOrDefault(u => u.Id == id).AspNetRoles.AsQueryable() : null;
        }

        public AspNetRole GetById(string id)
        {
            return Entities.AspNetRoles.FirstOrDefault(r => r.Id == id);
        }

        public void Add(AspNetRole role)
        {
            Entities.AspNetRoles.Add(role);
        }

        public void Delete(string id)
        {
            
            Entities.AspNetRoles.Remove(GetById(id));
        }


        public void Save()
        {
            Entities.SaveChanges();
        }
    }
}
