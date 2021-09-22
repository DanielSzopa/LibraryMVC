using AutoMapper;
using LibraryMVC.Domain.Interfaces;
using LibraryMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryMVC.Application
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
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
