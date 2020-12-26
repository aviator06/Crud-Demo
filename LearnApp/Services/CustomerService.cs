using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnApp.Models;
using MongoDB.Driver;

namespace LearnApp.Services
{
    
    public class CustomerService
    {
        private readonly IMongoCollection<Customer> customers;

        public CustomerService(ICustomerDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            customers = database.GetCollection<Customer>(settings.CustomerCollectionName);
        }

        public Customer Get(string name)
        {
            return customers.Find(customer => customer.Name == name).FirstOrDefault();
        }

        public List<Customer> Get() => customers.Find(customer => true).ToList();
            //return this.customers.Find(customer => true).ToList();
        

        public Customer Create(Customer customer)
        {
            customers.InsertOne(customer);
            return customer;
        }

        public void Update(string name, Customer newCustomer)
        {
            customers.ReplaceOne(customer => customer.Name == name, newCustomer);
        }
        public void Remove(string name)
        {
            customers.DeleteOne(customer => customer.Name == name);
        }


    }

}
