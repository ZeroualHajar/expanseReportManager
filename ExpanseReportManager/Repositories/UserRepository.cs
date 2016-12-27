using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExpanseReportManagerModel;

namespace ExpanseReportManager.Repositories
{
    public class UserRepository
    {
        public NotesDeFraisEntities Entities;

        public UserRepository(NotesDeFraisEntities entities)
        {
            this.Entities = entities;
        }

        public AspNetUser GetById(string id)
        {
            return Entities.AspNetUsers.FirstOrDefault(u => u.Id.ToString() == id);
        }

        public string GetEmployeeId(string userId)
        {
            return Entities.AspNetUsers.FirstOrDefault(u => u.Id.ToString() == userId) != null ?
                Entities.AspNetUsers.FirstOrDefault(u => u.Id.ToString() == userId).Employees.First().Employee_ID.ToString() : null;
        }

        public void Add(AspNetUser user)
        {
            Entities.AspNetUsers.Add(user);
        }

        public void Save()
        {
            Entities.SaveChanges();
        }
    }
}