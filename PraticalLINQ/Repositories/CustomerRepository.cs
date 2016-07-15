using PraticalLINQ.Implementations;
using PraticalLINQ.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraticalLINQ
{
    public class CustomerRepository
    {
        public Customer Find(List<Customer> customerList, int customerId)
        {
            return customerList.FirstOrDefault(c => c.Id == customerId);
            //Same as:
            //return customerList.FirstOrDefault(
            //    delegate (Customer c)
            //    {
            //        if (c.Id == customerId)
            //            return true;
            //        return false;
            //    });

            // -- Query Syntax --
            //var query = from customer in customerList
            //            where customer.Id == customerId
            //            select customer;

            //return query.FirstOrDefault();
            
            // -- ALTERNATIVE --
            //foreach (var c in customerList)
            //    if (c.Id == customerId) return c;

            ////else
            //return null;
        }

        public IEnumerable<Customer> SortByName(List<Customer> customerList)
        {
            return customerList
                .OrderBy(c => c.LastName)
                .ThenBy(c => c.FirstName);
        }

        public IEnumerable<Customer> SortByNameDescending(List<Customer> customerList)
        {
            return customerList
                .OrderByDescending(c => c.LastName)
                .ThenByDescending(c => c.FirstName);
        }

        public IEnumerable<Customer> SortByType(List<Customer> customerList)
        {
            return customerList
                .OrderBy(c => c.TypeId);
        }

        public IEnumerable<string> GetNames(List<Customer> customerList)
        {
            var query = customerList.Select(c => $"{c.LastName}, {c.FirstName}");
            return query;
        }

        public dynamic GetNamesAndEmail(List<Customer> customerList)
        {
            var query = customerList
                .Select(c => new {
                    Name = $"{c.LastName}, {c.FirstName}",
                    Email = c.Email});

            foreach(var item in query)
                Console.WriteLine($"{item.Name} : {item.Email}");

            return query;
        }

        public dynamic GetNamesAndType(List<Customer> customerList,
                                       List<CustomerType> customerTypeList)
        {
            var query = customerList
                .Join(customerTypeList,
                      customer => customer.TypeId,
                      type => type.TypeId,
                      (customer, type) => new {
                          Name = $"{customer.LastName}, {customer.FirstName}",
                          Type = type.TypeName });

            foreach (var item in query)
                Console.WriteLine($"{item.Name} : {item.Type}");

            return query;

        }

        public IEnumerable<Customer> GetOverDueCustomers(List<Customer> customerList)
        {
            var query = customerList
                .SelectMany(
                    c => c.InvoiceList.Where(i => i.Paid.HasValue == false),
                    (customer, invoice) => customer);
            return query;
        }

        public dynamic GetInvoiceTotalByCustomerType(
            List<Customer> customerList,
            List<CustomerType> customerTypeList)
        {
            var customerTypeQuery = customerList
                .Join(customerTypeList,
                      c => c.TypeId,
                      type => type.TypeId,
                      (c, t) => new
                      {
                          CustomerInstance = c,
                          CustomerTypeName = t
                      });

            var query = customerTypeQuery
                .GroupBy(customer =>
                    //We want to eventuall group by TypeId
                    customer.CustomerTypeName, 

                    // We select each customer and find the sum of their invoices
                    c => c.CustomerInstance.InvoiceList.Sum(invoice => invoice.TotalAmount),

                    // Then we project onto a new type, the TypeId matched with the
                    // sum of all invoices of all customers, that match that TypeId 
                    (groupKey, invoiceTotalForIndividualCustomers) => new
                    {
                        TypeOfCustomer = groupKey.TypeName,
                        InvoicedAmount = invoiceTotalForIndividualCustomers.Sum()
                    });

            foreach (var item in query)
            {
                Console.WriteLine($"{item.TypeOfCustomer} : {item.InvoicedAmount}");
            }

            return query;
        }

        public List<Customer> Retrieve()
        {
            var invoiceRepo = new InvoiceRepository();

            return new List<Customer>{
                new Customer() {
                    Id = 1,
                    FirstName = "Frodo",
                    LastName = "Baggins",
                    Email = "fb@hob.me",
                    TypeId = 1,
                    InvoiceList = invoiceRepo.Retrieve(1)},
                new Customer() {
                    Id = 2,
                    FirstName = "Bilbo",
                    LastName = "Baggins",
                    Email = "bb@hob.me",
                    TypeId = null,
                    InvoiceList = invoiceRepo.Retrieve(2)},
                new Customer() {
                    Id = 3,
                    FirstName = "Samwise",
                    LastName = "Gamgee",
                    Email = "sg@hob.me",
                    TypeId = 1,
                    InvoiceList = invoiceRepo.Retrieve(3)},
                new Customer() {
                    Id = 4,
                    FirstName = "Rosie",
                    LastName = "Cotton",
                    Email = "rc@hob.me",
                    TypeId = 2,
                    InvoiceList = invoiceRepo.Retrieve(4)}};
        }
    }
}
