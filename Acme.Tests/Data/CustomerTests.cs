using System;
using Acme.Data.DbContext;
using Acme.Data.Interfaces;
using Acme.Data.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acme.Tests.Data
{
    [TestClass]
    public class CustomerTests
    {
        ICustomer icustomer;

        public CustomerTests()
        {
            icustomer = new CustomerRepository();
        }

        [TestMethod]
        public void SaveCustomer()
        {
            var customer = new Customer()
            {
                FirstName = "Isabelle",
                MiddleName = "Cruz",
                LastName = "Granada",
                Age = 35,
                Birthdate = new DateTime(1986, 10, 26)
            };

            var result = icustomer.SaveCustomer(customer);
            Assert.IsTrue(result.IsSuccess);
        }

        [TestMethod]
        public void GetAllCustomers()
        {
            var result = icustomer.GetAllCustomers();
            Assert.IsTrue(result.IsSuccess);
            Assert.IsNotNull(result.Result);
        }

        [TestMethod]
        public void GetCustomerByCustomerID()
        {
            var result = icustomer.GetCustomerByCustomerID(1);
            Assert.IsTrue(result.IsSuccess);
            Assert.IsNotNull(result.Result);
        }

        [TestMethod]
        public void DeleteCustomer()
        {
            var result = icustomer.DeleteCustomer(7);
            Assert.IsTrue(result.IsSuccess);
        }

        [TestMethod]
        public void UpdateCustomer()
        {
            var customer = new Customer()
            {
                CustomerID = 11,
                FirstName = "Isabelle",
                MiddleName = "Cruz",
                LastName = "Granada",
                Age = 35,
                Birthdate = new DateTime(1986, 10, 26)
            };

            var result = icustomer.UpdateCustomer(customer);
            Assert.IsTrue(result.IsSuccess);
        }
    }
}
