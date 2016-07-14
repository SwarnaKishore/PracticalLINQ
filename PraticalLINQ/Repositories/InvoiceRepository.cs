using PraticalLINQ.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraticalLINQ.Repositories
{
    public class InvoiceRepository
    {
        public List<Invoice> Retrieve(int customerId)
        {
            var result = new List<Invoice>(){
                new Invoice() {
                    InvoiceId = 1,
                    CustomerId = 1,
                    InvoiceDate = new DateTime(2013, 6, 20),
                    DueDate = new DateTime(2013, 8, 29),
                    Paid = null},
                new Invoice() {
                    InvoiceId = 2,
                    CustomerId = 1,
                    InvoiceDate = new DateTime(2013, 7, 20),
                    DueDate = new DateTime(2013, 8, 20),
                    Paid = null},
                new Invoice() {
                    InvoiceId = 3,
                    CustomerId = 2,
                    InvoiceDate = new DateTime(2013, 7, 25),
                    DueDate = new DateTime(2013, 8, 25),
                    Paid = null},
                new Invoice() {
                    InvoiceId = 4,
                    CustomerId = 3,
                    InvoiceDate = new DateTime(2013, 7, 1),
                    DueDate = new DateTime(2013, 9, 1),
                    Paid = true}};

            return result.Where(i => i.CustomerId == customerId).ToList();
        }
    }
}
