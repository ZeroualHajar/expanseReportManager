using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExpanseReportManager.Models;
using ExpanseReportManagerModel;
using ExpanseReportManager.Repositories;
using ExpanseReportManager.Mapper;


namespace ExpanseReportManager.Services
{
    public class CustomerService
    {
        private CustomerMapper Mapper;
        private CustomerRepository Repository;

        public CustomerService(NotesDeFraisEntities entities)
        {
            this.Mapper = new CustomerMapper();
            this.Repository = new CustomerRepository(entities);
        }

        public ICollection<CustomerViewModels> GetAll()
        {
            return Mapper.AllToModel(Repository.GetAll());
        }

        public CustomerViewModels GetById(string id)
        {
            return Mapper.DataToModel(Repository.GetById(id));
        }

        public void Add(CustomerViewModels client)
        {
            Customer customer = new Customer();
            customer.Customer_ID = Guid.NewGuid();

            Repository.Add(Mapper.ModelToData(customer, client));
           
            Repository.Save();
        }

        public void Edit(CustomerViewModels client)
        {
            Customer customer = Repository.GetById(client.Id);
            Mapper.ModelToData(customer,client);
            Repository.Save();
        }

        public void Delete(string id)
        {
            Repository.delete(Repository.GetById(id));
            Repository.Save();
        }

        public ICollection<CustomerViewModels> Search(string query)
        {
            return Mapper.AllToModel(Repository.Search(query));
        }

    }
}