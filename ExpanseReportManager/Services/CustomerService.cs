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
        CustomerMapper Mapper;
        CustomerRepository Repository;

        public CustomerService()
        {
            this.Mapper = new CustomerMapper();
            this.Repository = new CustomerRepository(new NotesDeFraisEntities());
        }

        public ICollection<CustomerViewModels> GetAll()
        {
            ICollection<CustomerViewModels> result = new List<CustomerViewModels>();
            IQueryable<Customer> liste = Repository.GetAll();
            foreach(Customer c in liste)
            {
                result.Add(Mapper.DataToModel(c));
            }
            return result;
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

        public List<CustomerViewModels> Search(string query)
        {
            List<CustomerViewModels> result = new List<CustomerViewModels>();

            IQueryable<Customer> customers = Repository.Search(query);
            foreach (Customer res in customers)
            {
                result.Add(Mapper.DataToModel(res));
            }

            return result;
        }

    }
}