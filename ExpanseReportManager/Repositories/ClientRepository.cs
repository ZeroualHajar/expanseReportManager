using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExpanseReportManagerModel;


namespace ExpanseReportManager.Repositories
{
    public class ClientRepository
    {
        public NotesDeFraisEntities Entities;

        public ClientRepository(NotesDeFraisEntities entities)
        {
            this.Entities = entities;
        }

        public IQueryable<Customer> GetAll()
        {
            return Entities.Customers;
        }

        public Customer GetById(string id)
        {
            return Entities.Customers.FirstOrDefault(c => c.Customer_ID.ToString() == id);
        }

        public void Add(Customer customer)
        {
            Entities.Customers.Add(customer);
        }

        public void delete(string id)
        {
            Entities.Customers.Remove(GetById(id));
        }

        public void save()
        {
            Entities.SaveChanges();
        }

        public IQueryable<Customer> Search(string query)
        {
            return Entities.Customers.Where(
                c => c.Name.ToUpper().Contains(query.ToUpper()) ||
                    c.Code.ToUpper().Contains(query.ToUpper()) 
            );
        }



    }
}