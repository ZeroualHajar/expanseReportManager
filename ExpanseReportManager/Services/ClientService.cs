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
    public class ClientService
    {
        ClientMapper Mapper;
        ClientRepository Repository;

        public ClientService()
        {
            this.Mapper = new ClientMapper();
            this.Repository = new ClientRepository(new NotesDeFraisEntities());
        }

        public ICollection<ClientViewModel> GetAll()
        {
            ICollection<ClientViewModel> result = new List<ClientViewModel>();
            IQueryable<Customer> liste = Repository.GetAll();
            foreach(Customer c in liste)
            {
                result.Add(Mapper.DataToModel(c));
            }
            return result;
        }

        public ClientViewModel GetById(string id)
        {
            return Mapper.DataToModel(Repository.GetById(id));
        }

        public void Add(ClientViewModel client)
        {
            Customer customer = new Customer();
            customer.Customer_ID = Guid.NewGuid();

            Repository.Add(Mapper.ModelToData(customer, client));
           
            Repository.save();
        }

        public void Edit(ClientViewModel client)
        {
            Customer customer = Repository.GetById(client.Id);
            Mapper.ModelToData(customer,client);
            Repository.save();


        }

    }
}