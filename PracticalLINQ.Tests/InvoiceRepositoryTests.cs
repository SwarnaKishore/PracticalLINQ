using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PraticalLINQ.Repositories;

namespace PracticalLINQ.Tests
{
    [TestClass]
    public class InvoiceRepositoryTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void CalculateTotalAmountInvoicedTest()
        {
            var repo = new InvoiceRepository();
            var invoiceList = repo.Retrieve();

            var actual = repo.CalculateTotalAmountInvoiced(invoiceList);

            Assert.AreEqual(1333.14m, actual);
        }

        [TestMethod]
        public void CalculateTotalNumberOfUnitsSoldTest()
        {
            var repo = new InvoiceRepository();
            var invoiceList = repo.Retrieve();

            var actual = repo.CalculateTotalNumberOfUnitsSold(invoiceList);

            Assert.AreEqual(136, actual);
        }

        [TestMethod]
        public void CalculateInvoiceTotalByIsPaidTest()
        {
            var repo = new InvoiceRepository();
            var invoiceList = repo.Retrieve();

            var query = repo.GetInvoiceTotalByPaid(invoiceList);
        }

        [TestMethod]
        public void CalculateInvoiceTotalByPaidAndMonthTest()
        {
            var repo = new InvoiceRepository();
            var invoiceList = repo.Retrieve();

            var query = repo.GetInvoiceTotalByPaidAndMonth(invoiceList);
        }

        [TestMethod]
        public void CalculateMeanTest()
        {
            var repo = new InvoiceRepository();
            var invoiceList = repo.Retrieve();

            var actual = repo.CalculateMean(invoiceList);

            Assert.AreEqual(6.875m, actual);
        }

        [TestMethod]
        public void CalculateMedianTest()
        {
            var repo = new InvoiceRepository();
            var invoiceList = repo.Retrieve();

            var actual = repo.CalculateMedian(invoiceList);

            Assert.AreEqual(10m, actual);
        }

        [TestMethod]
        public void CalculateModeTest()
        {
            var repo = new InvoiceRepository();
            var invoiceList = repo.Retrieve();

            var actual = repo.CalculateMode(invoiceList);

            Assert.AreEqual(10m, actual);
        }
    }
}
