using LibraryMVC.Domain.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace LibraryMVC.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        int AddCustomer(Customer customer);
        int GetCustomerIdByUserId(string userId);
        Customer GetCustomerByUserId(string id);
        Customer GetCustomerByCustomerId(int id);
        int UpdateCustomer(Customer customer);
        IQueryable<Customer> GetAllCustomers();
    }
}
