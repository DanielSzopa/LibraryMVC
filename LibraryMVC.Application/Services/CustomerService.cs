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
        private readonly IUserService _userService;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper, IPaginationService paginationService, IUserService userService)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _paginationService = paginationService;
            _userService = userService;
        }

        public int AddCustomer(NewCustomerVm newCustomerVm)
        {
            var customer = _mapper.Map<Customer>(newCustomerVm);      
            
            if (!(newCustomerVm.isLocalAccount))
            {
                var userId = _userService.CreateUser(newCustomerVm.CustomerContactDetail.Mail, newCustomerVm.Password);
                customer.UserId = userId.Result;
                _userService.ChangeCustomerRoleToUser(userId.Result);
            }          
            var customerId = _customerRepository.AddCustomer(customer);
            return customerId;
        }

        public void AddCustomerAfterConfirmEmail(string userId, string mail)
        {
            _userService.ChangeCustomerRoleToUser(userId);
            Customer customer = new Customer();
            Address adress = new Address();
            CustomerContactDetail customerContactDetail = new CustomerContactDetail();
            TelephoneNumber telephoneNumber = new TelephoneNumber();
            TelephoneNumber telephoneNumber2 = new TelephoneNumber();
            customerContactDetail.TelephoneNumbers = new List<TelephoneNumber> { telephoneNumber, telephoneNumber2 };
            customerContactDetail.Mail = mail;

            customer.CustomerContactDetail = customerContactDetail;
            customer.Address = adress;

            customer.UserId = userId;
            _customerRepository.AddCustomer(customer);
        }

        public int UpdateCustomer(NewCustomerVm customerVm)
        {
            var customer = _mapper.Map<Customer>(customerVm);
            var updateCustomerId =  _customerRepository.UpdateCustomer(customer);
            return updateCustomerId;
        }

        public bool IsCustomerDetailsAreCorrect(string userId)
        {
            var customer = _customerRepository.GetCustomerByUserId(userId);
            if(customer.FirstName == null || customer.LastName == null || customer.Pesel == null)
            {
                return false;
            }
            return true;
            
        }

        public int GetCustomerIdByUserId(string userId)
        {
            var customerId = _customerRepository.GetCustomerIdByUserId(userId);
            return customerId;
        }

        public NewCustomerVm GetCustomerForEdit(int id)
        {
            var customer = _customerRepository.GetCustomerByCustomerId(id);
            var customerVm = _mapper.Map<NewCustomerVm>(customer);
            if (customer.CustomerContactDetail is null)
            {
                customerVm.CustomerContactDetail = new CustomerContactDetailsVm();
            }
            else
            {
                customerVm.CustomerContactDetail.TelephoneNumbers = customer.CustomerContactDetail.TelephoneNumbers;
            }
            return customerVm;
        }

        public CustomerForReservationVm GetCustomerForReservationByUserId(string userId)
        {
            var customer = _customerRepository.GetCustomerByUserId(userId);
            var customerForReservationVm = _mapper.Map<CustomerForReservationVm>(customer);
            return customerForReservationVm;
        }

        public CustomerDetailsVm GetCustomerDetailsByCustomerId(int customerId)
        {
            var customer = _customerRepository.GetCustomerByCustomerId(customerId);
            var customerVm = _mapper.Map<CustomerDetailsVm>(customer);
            return customerVm;
        }

        public CustomerDetailsVm GetCustomerDetailsByUserId(string currentUserId)
        {
            var customer = _customerRepository.GetCustomerByUserId(currentUserId);
            var customerVm = _mapper.Map<CustomerDetailsVm>(customer);
            return customerVm;
        }

        public CustomerListVm GetAllCustomerToList(int pageNumber, int pageSize, string searchString)
        {
            var customers = _customerRepository.GetAllCustomers()
                .Where(c => (c.FirstName + " " + c.LastName)
                .Contains(searchString))
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

        public IQueryable<CustomerFullNameVm> GetAllCustomersFullName()
        {
            var customers = _customerRepository.GetAllCustomers();
            var customersVm = customers.ProjectTo<CustomerFullNameVm>(_mapper.ConfigurationProvider);
            return customersVm;
        }
       
    }
}
