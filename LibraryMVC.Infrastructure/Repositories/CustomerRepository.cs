using LibraryMVC.Domain.Interfaces;
using LibraryMVC.Domain.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace LibraryMVC.Infrastructure
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly Context _context;
        public CustomerRepository(Context context)
        {
            _context = context;
        }

        public int AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer.Id;
        }

        public IQueryable<Customer> GetAllCustomers()
        {
            return _context.Customers;
        }

        public Customer GetCustomerByCustomerId(int id)
        {
            var customer = _context.Customers
                .Include(c => c.CustomerContactDetail)
                .ThenInclude(n => n.TelephoneNumbers)
                .Include(c => c.Address)
                .FirstOrDefault(c => c.Id == id);
            return customer;
        }

        public Customer GetCustomerByUserId(string id)
        {
           var customer = _context.Customers
                .Include(c=>c.CustomerContactDetail)
                .ThenInclude(n=>n.TelephoneNumbers)
                .Include(c => c.Address)
                .FirstOrDefault(c => c.UserId == id);
            return customer;
        }

        public int UpdateCustomer(Customer customer)
        {         
            _context.Update<Customer>(customer);
            _context.SaveChanges();
            return customer.Id;
        }
    }
}
