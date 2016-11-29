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
        public ClientViewModel DataToModel(Customer customer)
        {
            ClientViewModel client = new ClientViewModel();
            client.Id = customer.Customer_ID.ToString();
            client.Name = customer.Name;
            client.Code = customer.Code;
            return client;
        }

        public Customer ModelToData(Customer customer,ClientViewModel client)
        {
            customer.Name = client.Name;
            customer.Code = client.Code;
            return customer;

        }
    }
}