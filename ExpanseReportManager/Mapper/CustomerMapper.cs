using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExpanseReportManager.Models;
using ExpanseReportManagerModel;

namespace ExpanseReportManager.Mapper
{
    public class CustomerMapper
    {
        public ICollection<CustomerViewModels> AllToModel(IQueryable<Customer> customers)
        {
            return customers.Select(c => new CustomerViewModels
            {
                Id = c.Customer_ID.ToString(),
                Name = c.Name,
                Code = c.Code

            }).ToList();
        }

        public CustomerViewModels DataToModel(Customer customer)
        {
            return new CustomerViewModels
            {
                Id = customer.Customer_ID.ToString(),
                Name = customer.Name,
                Code = customer.Code
            };
        }

        public Customer ModelToData(Customer customer,CustomerViewModels model)
        {
            customer.Name = model.Name;
            customer.Code = model.Code;

            return customer;
        }
    }
}