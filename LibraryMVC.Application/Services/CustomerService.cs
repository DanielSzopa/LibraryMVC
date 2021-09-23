using AutoMapper;
using LibraryMVC.Domain.Interfaces;
using LibraryMVC.Domain.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using AutoMapper.QueryableExtensions;

namespace LibraryMVC.Application
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly IPaginationService _paginationService;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper, IPaginationService paginationService)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _paginationService = paginationService;
        }

        public void AddCustomerAfterConfirmEmail(string userId, string mail)
        {
            Customer customer = new Customer();
            Address adress = new Address();
            CustomerContactDetail customerContactDetail = new CustomerContactDetail();
            TelephoneNumber telephoneNumber = new TelephoneNumber();
            customerContactDetail.TelephoneNumbers = new List<TelephoneNumber> { telephoneNumber };
            customerContactDetail.Mail = mail;


            customer.CustomerContactDetail = customerContactDetail;
            customer.Address = adress;

            customer.UserId = userId;
            _customerRepository.AddCustomer(customer);
        }

        public IQueryable<Customer> GetAllCustomers()
        {
            var customers = _customerRepository.GetAllCustomers();
            return customers;
        }

        public CustomerListVm GetAllCustomerToList(int pageNumber, int pageSize, string searchString)
        {
            var customers = GetAllCustomers().Where(c => (c.FirstName + " " + c.LastName).Contains(searchString))
            .ProjectTo<CustomerForListVm>(_mapper.ConfigurationProvider)
            .ToList();

            var records = _paginationService.ReturnRecordsToShow<CustomerForListVm>(pageNumber, pageSize, customers);

            var result = new CustomerListVm
            {
                Customers = records,
                PageNumber = pageNumber,
                PageSize = pageSize,
                SearchString = searchString,
                Count = customers.Count
            };
            return result;
        }

        public Customer GetCustomerByUserId(string userId)
        {
            return _customerRepository.GetCustomerByUserId(userId);
        }

        public CustomerDetailsVm GetCustomerDetailsByUserId(string currentUserId)
        {
            var customer = GetCustomerByUserId(currentUserId);
            var customerVm = _mapper.Map<CustomerDetailsVm>(customer);
            return customerVm;
        }
    }
}
