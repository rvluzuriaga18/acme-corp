using Acme.Data.DbContext;
using System.Collections.Generic;

namespace Acme.Data.Interfaces
{
    public interface ICustomer
    {
        OperationResult<List<Customer>> GetAllCustomers();
        OperationResult<Customer> GetCustomerByCustomerID(long customerID);
        OperationResult<bool> SaveCustomer(Customer customer);
        OperationResult<bool> UpdateCustomer(Customer customer);
        OperationResult<bool> DeleteCustomer(long customerID);
    }
}
