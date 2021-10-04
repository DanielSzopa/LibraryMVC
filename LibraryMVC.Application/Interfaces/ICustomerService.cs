using LibraryMVC.Domain.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace LibraryMVC.Application
{
    public interface ICustomerService
    {
        void AddCustomerAfterConfirmEmail(string userId, string mail);
        int AddCustomer(NewCustomerVm newCustomerVm);
        NewCustomerVm RemoveDefaultNumbersOfCustomers(NewCustomerVm customerVm);
        Customer GetCustomerByUserId(string userId);
        CustomerDetailsVm GetCustomerDetailsByUserId(string userId);
        CustomerListVm GetAllCustomerToList(int pageNumber, int pageSize, string searchString);
        IQueryable<Customer> GetAllCustomers();
    }
}
