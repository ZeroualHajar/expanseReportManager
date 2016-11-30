using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExpanseReportManager.Models;
using ExpanseReportManagerModel;

namespace ExpanseReportManager.Mapper
{
    public class ClientMapper
    {
        public CustomerViewModel DataToModel(Customer customer)
        {
            CustomerViewModel client = new CustomerViewModel();
            client.Id = customer.Customer_ID.ToString();
            client.Name = customer.Name;
            client.Code = customer.Code;
            return client;
        }

        public Customer ModelToData(Customer customer,CustomerViewModel client)
        {
            customer.Name = client.Name;
            customer.Code = client.Code;
            return customer;

        }
    }
}