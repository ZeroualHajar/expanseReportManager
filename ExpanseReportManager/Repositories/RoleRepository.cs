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

        public AspNetRole GetById(String id)
        {
            return Entities.AspNetRoles.FirstOrDefault(r => r.Id == id);
        }

        public void Add(AspNetRole role)
        {
            Entities.AspNetRoles.Add(role);
        }

        public void Delete(AspNetRole role)
        {
            Entities.AspNetRoles.Remove(role);
        }

        public void Save()
        {
            Entities.SaveChanges();
        }
    }
}
