using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExpanseReportManagerModel;


namespace ExpanseReportManager.Repositories
{
    public class CustomerRepository
    {
        public NotesDeFraisEntities Entities;

        public CustomerRepository(NotesDeFraisEntities entities)
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

        public void delete(Customer customer)
        {
            Entities.Customers.Remove(customer);
        }

        public void Save()
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