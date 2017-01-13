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
            AspNetUser user = Entities.AspNetUsers.FirstOrDefault(u => u.Id.ToString() == userId);
            return user != null && user.Employees.Any() ?
                user.Employees.First().Employee_ID.ToString() : null;
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