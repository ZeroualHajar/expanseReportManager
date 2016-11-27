using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExpanseReportManager.Models;
using ExpanseReportManager.Services;
using ExpanseReportManagerModel;

namespace ExpanseReportManager.Mapper
{
    public class EmployeeMapper
    {
        public EmployeeViewModels DataToModel(Employee employee)
        {
            EmployeeViewModels result = new EmployeeViewModels()
            {
                Id = employee.Employee_ID.ToString(),
                UserId = employee.User_ID,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                Telephone = employee.Telephone,
                PoleId = employee.Pole_ID
            };

            return result;
        }

        public Employee ModelToData(Employee employee, EmployeeViewModels model)
        {
            Employee result = new Employee()
            {
                User_ID = model.UserId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Telephone = model.Telephone,
                Pole_ID = model.PoleId
            };

            return result;
        }
    }
}
