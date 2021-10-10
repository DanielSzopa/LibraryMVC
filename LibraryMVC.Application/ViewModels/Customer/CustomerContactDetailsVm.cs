using AutoMapper;
using LibraryMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryMVC.Application
{
    public class CustomerContactDetailsVm : IMapFrom<CustomerDetailsVm>
    {
        public int Id { get; set; }
        public string Mail { get; set; }
        public List<TelephoneNumber> TelephoneNumbers { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CustomerContactDetail, CustomerContactDetailsVm>()
                .ReverseMap();
        }
    }
}
