using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExpanseReportManager.Mapper;
using ExpanseReportManager.Repositories;
using ExpanseReportManagerModel;
using ExpanseReportManager.Models;

namespace ExpanseReportManager.Services
{
    public class EmployeeService
    {
        public EmployeeRepository Repository;
        public EmployeeMapper Mapper;

        public EmployeeService()
        {
            this.Repository = new EmployeeRepository(new NotesDeFraisEntities());
            this.Mapper = new EmployeeMapper();
        }

        public ICollection<EmployeeViewModels> GetAll()
        {
            ICollection<EmployeeViewModels> result = new List<EmployeeViewModels>();

            IQueryable<Employee> employees = Repository.GetAll();

            foreach (Employee employee in employees)
            {
                result.Add(Mapper.DataToModel(employee));
            }

            return result;
        }

        public EmployeeViewModels GetById(string id)
        {
            return Mapper.DataToModel(Repository.GetById(id));
        }

        public void Add(EmployeeViewModels model)
        {
            Employee employee = new Employee();
            employee.Employee_ID = Guid.NewGuid();

            Repository.Add(Mapper.ModelToData(employee, model));
            Repository.Save();
        }

        public void Delete(String id)
        {
            Employee employee = Repository.GetById(id);

            Repository.Delete(employee);
            Repository.Save();
        }

        public ICollection<EmployeeViewModels> GetAllByPole(string id)
        {
            ICollection<EmployeeViewModels> result = new List<EmployeeViewModels>();

            IQueryable<Employee> employees = Repository.GetAll().Where(e => e.Pole_ID.ToString() == id);

            foreach (Employee employee in employees)
            {
                result.Add(Mapper.DataToModel(employee));
            }

            return result;
        }
    }
}