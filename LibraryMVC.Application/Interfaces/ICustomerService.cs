using LibraryMVC.Domain.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace LibraryMVC.Application
{
    public interface ICustomerService
    {
        Customer GetCustomerByUserId(string userId);
        CustomerDetailsVm GetCustomerDetailsByUserId(string userId);
        CustomerListVm GetAllCustomerToList(int pageNumber, int pageSize, string searchString);
        IQueryable<Customer> GetAllCustomers();
    }
}
