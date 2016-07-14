using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PraticalLINQ;
using System.Linq;

namespace PracticalLINQ.Tests
{
    [TestClass]
    public class CustomerRepositoryTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void Find_ExistingCustomer()
        {
            var repo = new CustomerRepository();
            var customerList = repo.Retrieve();

            var result = repo.Find(customerList, 2);

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Id);
            Assert.AreEqual("Baggins", result.LastName);
            Assert.AreEqual("Bilbo", result.FirstName);
        }

        [TestMethod]
        public void Find_NotExistingCustomer()
        {
            var repo = new CustomerRepository();
            var customerList = repo.Retrieve();

            var result = repo.Find(customerList, 42);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void SortByNameTest()
        {
            var repo = new CustomerRepository();
            var customerList = repo.Retrieve();

            var result = repo.SortByName(customerList);

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.First().Id);
            Assert.AreEqual("Baggins", result.First().LastName);
            Assert.AreEqual("Bilbo", result.First().FirstName);
        }

        [TestMethod]
        public void SortByNameDescendingTest()
        {
            var repo = new CustomerRepository();
            var customerList = repo.Retrieve();

            var result = repo.SortByName(customerList);

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.First().Id);
            Assert.AreEqual("Baggins", result.First().LastName);
            Assert.AreEqual("Bilbo", result.First().FirstName);
        }

        [TestMethod]
        public void SortByTypeTest()
        {
            var repo = new CustomerRepository();
            var customerList = repo.Retrieve();

            var result = repo.SortByType(customerList);

            Assert.IsNotNull(result);
            Assert.AreEqual(null, result.First().TypeId);
        }

        [TestMethod]
        public void GetNamesTest()
        {
            var repo = new CustomerRepository();
            var customerList = repo.Retrieve();

            var query = repo.GetNames(customerList);

            foreach (var item in query)
                TestContext.WriteLine(item);

            Assert.IsNotNull(query);
        }

        [TestMethod]
        public void GetNamesAndEmailTest()
        {
            var repo = new CustomerRepository();
            var customerList = repo.Retrieve();

            var query = repo.GetNamesAndEmail(customerList);

            //NOT REALLY A TEST
        }

        [TestMethod]
        public void GetNamesAndTypeTest()
        {
            var repo = new CustomerRepository();
            var customerList = repo.Retrieve();

            var typeRepo = new CustomerTypeRepository();
            var typeList = typeRepo.Retrieve();

            var query = repo.GetNamesAndType(customerList, typeList);

            //NOT REALLY A TEST
        }

        [TestMethod]
        public void GetOverDueCustomersTest()
        {
            var repo = new CustomerRepository();
            var customerList = repo.Retrieve();

            var query = repo.GetOverDueCustomers(customerList);

            foreach (var customer in query)
                TestContext.WriteLine($"{customer.LastName}, {customer.FirstName}");

            Assert.IsNotNull(query);

        }
    }
}
