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
                PoleId = employee.Pole_ID.ToString()
            };

            return result;
        }

        public Employee ModelToData(Employee employee, EmployeeViewModels model)
        {
            employee.User_ID = model.UserId;
            employee.FirstName = model.FirstName;
            employee.LastName = model.LastName;
            employee.Email = model.Email;
            employee.Telephone = model.Telephone;
            employee.Pole_ID = new Guid(model.PoleId);
            
            return employee;
        }
    }
}
