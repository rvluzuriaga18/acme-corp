using System;
using Acme.Data.DbContext;
using System.Collections.Generic;
using System.Linq;
using Acme.Data.Interfaces;

namespace Acme.Data.Services
{
    public class CustomerService: ICustomer
    {
        public OperationResult<List<Customer>> GetAllCustomers()
        {
            try
            {
                using (var db = new AcmeCorpContext())
                {
                    var result = db.Customers?.ToList();
                    return OperationResult<List<Customer>>.Success(result);
                }
            }
            catch (Exception ex)
            { return OperationResult<List<Customer>>.Failed(ex.ToString()); }
        }

        public OperationResult<Customer> GetCustomerByCustomerID(long customerID)
        {
            try
            {
                using (var db = new AcmeCorpContext())
                {
                    var result = db.Customers.Where(x => x.CustomerID == customerID)
                                       .FirstOrDefault();

                    if (result == null) throw new Exception("Record not found.");

                    return OperationResult<Customer>.Success(result);
                }
            }
            catch (Exception ex)
            { return OperationResult<Customer>.Failed(ex.ToString()); }
        }

        public OperationResult<bool> SaveCustomer(Customer customer)
        {
            try
            {
                using (var db = new AcmeCorpContext())
                {
                    db.Customers.Add(customer);
                    db.SaveChanges();

                    return OperationResult<bool>.Success();
                }
            }
            catch (Exception ex)
            { return OperationResult<bool>.Failed(ex.ToString());}
        }

        public OperationResult<bool> DeleteCustomer(long customerID)
        {
            try
            {
                using (var db = new AcmeCorpContext())
                {
                    var customer = db.Customers.Where(x => x.CustomerID == customerID)
                        .FirstOrDefault();

                    if (customer == null) throw new Exception("Record not found.");

                    db.Customers.Remove(customer);
                    db.SaveChanges();

                    return OperationResult<bool>.Success();
                }
            }
            catch (Exception ex)
            { return OperationResult<bool>.Failed(ex.ToString()); }
        }

        public OperationResult<bool> UpdateCustomer(Customer customer)
        {
            try
            {
                using (var db = new AcmeCorpContext())
                {
                    var currentValues = db.Customers.Where(x => x.CustomerID == customer.CustomerID)
                        .FirstOrDefault();

                    if (currentValues == null) throw new Exception("Record not found.");

                    //Overwrite existing values
                    currentValues.FirstName = customer.FirstName;
                    currentValues.MiddleName = customer.MiddleName;
                    currentValues.LastName = customer.LastName;
                    currentValues.Age = customer.Age;
                    currentValues.Birthdate = customer.Birthdate;

                    db.SaveChanges();

                    return OperationResult<bool>.Success();
                }
            }
            catch (Exception ex)
            { return OperationResult<bool>.Failed(ex.ToString()); }
        }
    }
}
