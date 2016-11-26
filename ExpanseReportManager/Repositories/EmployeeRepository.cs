using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExpanseReportManagerModel;

namespace ExpanseReportManager.Repositories
{
    public class EmployeeRepository
    {
        public NotesDeFraisEntities entities;

        public EmployeeRepository(NotesDeFraisEntities entities)
        {
            this.entities = entities;
        }

        public IQueryable<Employee> GetAll()
        {
            return entities.Employees;
        }

        public Employee GetById(Guid id)
        {
            return entities.Employees.FirstOrDefault(e => e.Employee_ID == id);
        }

        public void Add(Employee employe)
        {
            entities.Employees.Add(employe);
        }

        public void Delete(Employee employee)
        {
            entities.Employees.Remove(employee);
        }
    }
}