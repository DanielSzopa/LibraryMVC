﻿using LibraryMVC.Domain.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace LibraryMVC.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        void AddCustomer(Customer customer);
        Customer GetCustomerByUserId(string id);
        IQueryable<Customer> GetAllCustomers();
    }
}
