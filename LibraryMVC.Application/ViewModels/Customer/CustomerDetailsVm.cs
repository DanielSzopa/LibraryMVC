using AutoMapper;
using LibraryMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryMVC.Application
{
    public class CustomerDetailsVm : IMapFrom<Customer>
    {
        public int Id { get; set; }      
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Pesel { get; set; }
        public string Mail { get; set; }
        public List<TelephoneNumber> Number { get; set; }
        public string Country { get; set; }
        public string Street { get; set; }
        public string PostCode { get; set; }
        public int NumberOfLocal { get; set; }
        public int NumberOfAccommodation { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Customer, CustomerDetailsVm>()
                .ForMember(d => d.Mail, opt => opt.MapFrom(s => s.CustomerContactDetail.Mail))
                .ForMember(d => d.Number, opt => opt.MapFrom(s => s.CustomerContactDetail.TelephoneNumbers))
                .ForMember(d => d.Country, opt => opt.MapFrom(s => s.Address.Country))
                .ForMember(d => d.Street, opt => opt.MapFrom(s => s.Address.Street))
                .ForMember(d => d.PostCode, opt => opt.MapFrom(s => s.Address.PostCode))
                .ForMember(d => d.NumberOfLocal, opt => opt.MapFrom(s => s.Address.NumberOfLocal))
                .ForMember(d => d.NumberOfAccommodation, opt => opt.MapFrom(s => s.Address.NumberOfAccommodation));
                
        }
    }
}
