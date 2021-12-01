﻿using AutoMapper;
using LibraryMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryMVC.Application
{ 
    public class CustomerFullNameVm : IMapFrom<Customer>
    {
        public int Id { get; set; }
        public string CustomerFullName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Customer, CustomerFullNameVm>()
                .ForMember(c => c.CustomerFullName, opt => opt.MapFrom(c => c.FirstName + " " + c.LastName + " " + c.Pesel));
        }
    }
}
