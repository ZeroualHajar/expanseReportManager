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
        ClientMapper Mapper;
        ClientRepository Repository;

        public CustomerService()
        {
            this.Mapper = new ClientMapper();
            this.Repository = new ClientRepository(new NotesDeFraisEntities());
        }

        public ICollection<CustomerViewModel> GetAll()
        {
            ICollection<CustomerViewModel> result = new List<CustomerViewModel>();
            IQueryable<Customer> liste = Repository.GetAll();
            foreach(Customer c in liste)
            {
                result.Add(Mapper.DataToModel(c));
            }
            return result;
        }

        public CustomerViewModel GetById(string id)
        {
            return Mapper.DataToModel(Repository.GetById(id));
        }

        public void Add(CustomerViewModel client)
        {
            Customer customer = new Customer();
            customer.Customer_ID = Guid.NewGuid();

            Repository.Add(Mapper.ModelToData(customer, client));
           
            Repository.save();
        }

        public void Edit(CustomerViewModel client)
        {
            Customer customer = Repository.GetById(client.Id);
            Mapper.ModelToData(customer,client);
            Repository.save();


        }

        public void Delete(string id)
        {
            Repository.delete(id);
            Repository.save();

        }

        public List<CustomerViewModel> Search(string query)
        {
            List<CustomerViewModel> result = new List<CustomerViewModel>();

            IQueryable<Customer> customers = Repository.Search(query);
            foreach (Customer res in customers)
            {
                result.Add(Mapper.DataToModel(res));
            }

            return result;
        }

    }
}