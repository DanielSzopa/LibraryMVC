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
        Customer GetCustomerById(int id);
        Customer GetCustomerByUserId(string userId);
        NewCustomerVm GetCustomerForEdit(int id);
        void UpdateCustomer(NewCustomerVm customerVm);
        CustomerDetailsVm GetCustomerDetailsByCustomerId(int customerId);
        CustomerDetailsVm GetCustomerDetailsByUserId(string userId);
        CustomerListVm GetAllCustomerToList(int pageNumber, int pageSize, string searchString);
        IQueryable<Customer> GetAllCustomers();
    }
}
