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
        public List<Invoice> Retrieve()
        {
            return new List<Invoice>(){
                new Invoice() {
                    InvoiceId = 1,
                    CustomerId = 1,
                    InvoiceDate = new DateTime(2013, 6, 20),
                    DueDate = new DateTime(2013, 8, 29),
                    Paid = null,
                    Amount = 199.99M,
                    NumberOfUnits = 20,
                    DiscountPercent=0M},
                new Invoice() {
                    InvoiceId = 2,
                    CustomerId = 1,
                    InvoiceDate = new DateTime(2013, 7, 20),
                    DueDate = new DateTime(2013, 8, 20),
                    Paid = null,
                    Amount = 98.50M,
                    NumberOfUnits = 10,
                    DiscountPercent=10M},
                new Invoice() {
                    InvoiceId = 3,
                    CustomerId = 2,
                    InvoiceDate = new DateTime(2013, 7, 25),
                    DueDate = new DateTime(2013, 8, 25),
                    Paid = null,
                    Amount = 250M,
                    NumberOfUnits = 25,
                    DiscountPercent=10M},
                new Invoice() {
                    InvoiceId = 4,
                    CustomerId = 3,
                    InvoiceDate = new DateTime(2013, 7, 1),
                    DueDate = new DateTime(2013, 9, 1),
                    Paid = true,
                    Amount = 20M,
                    NumberOfUnits = 2,
                    DiscountPercent=15M},
            new Invoice() {
                    InvoiceId = 5,
                    CustomerId = 1,
                    InvoiceDate = new DateTime(2013, 8, 20),
                    DueDate = new DateTime(2013, 9, 29),
                    Paid = true,
                    Amount = 225M,
                    NumberOfUnits = 22,
                    DiscountPercent=10M},
            new Invoice() {
                    InvoiceId = 6,
                    CustomerId = 2,
                    InvoiceDate = new DateTime(2013, 8, 20),
                    DueDate = new DateTime(2013, 8, 20),
                    Paid = false,
                    Amount = 75M,
                    NumberOfUnits = 8,
                    DiscountPercent=0M},
            new Invoice() {
                    InvoiceId = 7,
                    CustomerId = 3,
                    InvoiceDate = new DateTime(2013, 8, 25),
                    DueDate = new DateTime(2013, 9, 25),
                    Paid = null,
                    Amount = 500M,
                    NumberOfUnits = 42,
                    DiscountPercent=10M},
            new Invoice() {
                    InvoiceId = 8,
                    CustomerId = 4,
                    InvoiceDate = new DateTime(2013, 8, 1),
                    DueDate = new DateTime(2013, 9, 1),
                    Paid = true,
                    Amount = 75M,
                    NumberOfUnits = 7,
                    DiscountPercent=0M}};
        }

        public List<Invoice> Retrieve(int customerId)
        {
            var result = this.Retrieve();
            return result.Where(i => i.CustomerId == customerId).ToList();
        }

        public decimal CalculateTotalAmountInvoiced(List<Invoice> invoiceList) =>
            invoiceList.Sum(inv => inv.TotalAmount);

        public object CalculateTotalNumberOfUnitsSold(List<Invoice> invoiceList) =>
            invoiceList.Sum(inv => inv.NumberOfUnits);

        public dynamic GetInvoiceTotalByPaid(List<Invoice> invoiceList)
        {
            var query = invoiceList.GroupBy(
                inv => inv.Paid ?? false,
                inv => inv.TotalAmount,
                (groupKey, invTotal) => new {
                        Key = groupKey,
                        InvoicedAmount = invTotal.Sum() });

            foreach(var item in query)
                Console.WriteLine($"{item.Key} : {item.InvoicedAmount}");

            return query;
        }

        public dynamic GetInvoiceTotalByPaidAndMonth(List<Invoice> invoiceList)
        {
            var query = invoiceList.GroupBy(inv => new
            {
                Paid = inv.Paid ?? false,
                Month = inv.InvoiceDate.ToString("MMMM")
            },
                inv => inv.TotalAmount,
                (groupKey, invTotal) => new {
                    Key = groupKey,
                    InvoicedAmount = invTotal.Sum()
                });

            foreach (var item in query)
                Console.WriteLine($"{item.Key.Paid} ({item.Key.Month}) : {item.InvoicedAmount}");

            return query;
        }

        public decimal CalculateMean(List<Invoice> invoiceList)
        {
            return invoiceList.Average(invoice => invoice.DiscountPercent);
        }

        public object CalculateMedian(List<Invoice> invoiceList)
        {
            var list = invoiceList
                .OrderBy(invoice => invoice.DiscountPercent);

            int count = invoiceList.Count();
            int position = count / 2;

            decimal median;
            if ((count % 2) == 0)
            {
                median = (list.ElementAt(position).DiscountPercent +
                          list.ElementAt(position - 1).DiscountPercent) / 2;
            }
            else
            {
                median = list.ElementAt(position).DiscountPercent;
            }

            return median;

        }

        public object CalculateMode(List<Invoice> invoiceList)
        {
            return invoiceList
                .GroupBy(invoice => invoice.DiscountPercent)
                .OrderByDescending(group => group.Count())
                .Select(group => group.Key)
                .FirstOrDefault();
        }
    }
}
