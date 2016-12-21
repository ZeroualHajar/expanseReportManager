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
        public CustomerViewModels DataToModel(Customer customer)
        {
            CustomerViewModels result = new CustomerViewModels();
            result.Id = customer.Customer_ID.ToString();
            result.Name = customer.Name;
            result.Code = customer.Code;

            return result;
        }

        public Customer ModelToData(Customer customer,CustomerViewModels client)
        {
            customer.Name = client.Name;
            customer.Code = client.Code;
            return customer;

        }
    }
}