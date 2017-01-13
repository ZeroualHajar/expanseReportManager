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
        public PoleMapper PoleMapper;

        public EmployeeService(NotesDeFraisEntities entities)
        {
            this.Repository = new EmployeeRepository(entities);
            this.Mapper = new EmployeeMapper();
        }

        public EmployeeService() : this(new NotesDeFraisEntities())
        {
        }

        public ICollection<EmployeeViewModels> GetAll()
        {
            return Mapper.AllToModel(Repository.GetAll());
        }

        public EmployeeViewModels GetById(string id)
        {
            Employee employee = Repository.GetById(id);
            return employee == null ? null : Mapper.DataToModel(employee);
        }

        public EmployeeViewModels GetByUserId(string id)
        {
            return Mapper.DataToModel(Repository.GetByUserId(id));
        }

        public void Add(EmployeeViewModels model)
        {
            Employee employee = new Employee();
            employee.Employee_ID = Guid.NewGuid();

            Repository.Add(Mapper.ModelToData(employee, model));
            Repository.Save();
        }

        public bool HasRole(string employeeId, string roleId)
        {
            return Repository.GetById(employeeId)
                .AspNetUser.AspNetRoles.FirstOrDefault(r => r.Id == roleId) != null;
        }

        public void Associate(AddRoleToEmployeeViewModels model)
        {

            Repository.Associate(model.Employee, model.Roles);
            Repository.Save();
        }

        public void Delete(String id)
        {
            Repository.Delete(Repository.GetById(id));
            Repository.Save();
        }

        public ICollection<EmployeeViewModels> GetAllByPole(string id)
        {
            return Mapper.AllToModel(Repository.GetAll().Where(e => e.Pole_ID.ToString() == id));
        }

        public ICollection<EmployeeViewModels> GetAllFree()
        {
            return Mapper.AllToModel(Repository.GetAll().Where(e => e.Pole_ID == null));
        }

        public ICollection<EmployeeViewModels> SearchByPole(string poleId, string query)
        {
            return Mapper.AllToModel(Repository.SearchByPole(poleId, query));
        }

        public void AddToPole(string poleId, string employeeId)
        {
            Employee emp = Repository.GetById(employeeId);
            emp.Pole_ID = new Guid(poleId);

            Repository.Save();
        }

        public void RemoveFromPole(string poleId, string employeeId)
        {
            Employee emp = Repository.GetById(employeeId);

            if(emp.Pole_ID.ToString() == poleId)
            {
                emp.Pole_ID = null;
            }

            Repository.Save();
        }

        public bool IsManager(string userId)
        {
            return Repository.IsManager(userId);
        }

        public string GetManagerId(string employeeId)
        {
            Employee e = Repository.GetById(employeeId);

            return e == null || string.IsNullOrEmpty(e.Pole_ID.ToString()) ? null : e.Pole.Manager_ID.ToString();
        }
    }
}
