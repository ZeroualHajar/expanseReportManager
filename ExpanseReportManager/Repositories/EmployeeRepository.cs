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
            Entities.Employees.Remove(employee);
        }
        public void Save()
        {
            Entities.SaveChanges();
        }

    }
}