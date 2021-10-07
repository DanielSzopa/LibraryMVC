using AutoMapper;
using LibraryMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryMVC.Application
{
    public class AddressVm : IMapFrom<Address>
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string Locality { get; set; }
        public string Street { get; set; }
        public string PostCode { get; set; }
        public int NumberOfLocal { get; set; }
        public int NumberOfAccommodation { get; set; }
        public int CustomerId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Address, AddressVm>()
                .ReverseMap();
        }
    }  
}
