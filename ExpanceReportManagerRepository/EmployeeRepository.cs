using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpanseReportManagerModel;

namespace ExpanceReportManagerRepository
{
    class EmployeeRepository
    {
        public NotesDeFraisEntities Entities;
        public EmployeeRepository(NotesDeFraisEntities entities)
        {
            this.Entities = entities;
        }

        public Employee GetById(Guid id)
        {
            return Entities.Employees.FirstOrDefault(e => e.Employee_ID == id);
        }

        public void Add(Employee employee)
        {
            Entities.Employees.Add(employee);
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
