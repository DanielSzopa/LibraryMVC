using AutoMapper;
using LibraryMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryMVC.Application
{
    public class CustomerForListVm : IMapFrom<Customer>
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Mail { get; set; }
        public bool IsLocalAccount { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Customer, CustomerForListVm>()
                .ForMember(d => d.FullName, opt => opt.MapFrom(s => s.FirstName + " " + s.LastName))
                .ForMember(d => d.Mail, opt => opt.MapFrom(s => s.CustomerContactDetail.Mail));
        }
    }
}
