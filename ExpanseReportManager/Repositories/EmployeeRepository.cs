using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExpanseReportManagerModel;

namespace ExpanseReportManager.Repositories
{
    public class EmployeeRepository
    {
        public NotesDeFraisEntities Entities;

        public EmployeeRepository(NotesDeFraisEntities entities)
        {
            this.Entities = entities;
        }

        public IQueryable<Employee> GetAll()
        {
            return Entities.Employees;
        }

        public Employee GetById(string id)
        {
            return Entities.Employees.FirstOrDefault(e => e.Employee_ID.ToString() == id);
        }

        public void Add(Employee employe)
        {
            Entities.Employees.Add(employe);
        }

        public void Delete(Employee employee)
        {
            // Remove to user concern
            AspNetUser user = Entities.AspNetUsers.FirstOrDefault(u => u.Id == employee.User_ID);
            Entities.AspNetUsers.Remove(user);

            Entities.Employees.Remove(employee);
        }

        public void Save()
        {
            Entities.SaveChanges();
        }

        public IQueryable<Employee> SearchByPole(string poleId, string query)
        {
            return Entities.Employees.Where(
                e => e.Pole_ID.ToString() == poleId &&
                    (e.FirstName.ToUpper().Contains(query.ToUpper()) ||
                    e.LastName.ToUpper().Contains(query.ToUpper()))
            );
        }

    }
}