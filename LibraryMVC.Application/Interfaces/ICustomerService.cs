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
        int AddCustomer(NewCustomerVm newCustomerVm);
        void AddCustomerAfterConfirmEmail(string userId, string mail);        
        int UpdateCustomer(NewCustomerVm customerVm);
        bool IsCustomerDetailsAreCorrect(string userId);
        int GetCustomerIdByUserId(string userId);
        NewCustomerVm GetCustomerForEdit(int id);
        CustomerForReservationVm GetCustomerForReservationByUserId(string userId);
        CustomerDetailsVm GetCustomerDetailsByCustomerId(int customerId);
        CustomerDetailsVm GetCustomerDetailsByUserId(string userId);
        CustomerListVm GetAllCustomerToList(int pageNumber, int pageSize, string searchString);
        IQueryable<CustomerFullNameVm> GetAllCustomersFullName();

    }
}
