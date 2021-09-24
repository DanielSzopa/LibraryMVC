using AutoMapper;
using FluentValidation;
using LibraryMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryMVC.Application
{
    public class NewCustomerVm : IMapFrom<Customer>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Pesel { get; set; }
        public List<TelephoneNumber> Number { get; set; }
        public string Locality { get; set; }
        public string Country { get; set; }
        public string Street { get; set; }
        public string PostCode { get; set; }
        public int NumberOfLocal { get; set; }
        public int NumberOfAccommodation { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Customer, NewCustomerVm>()
                .ForMember(d => d.Mail, opt => opt.MapFrom(s => s.CustomerContactDetail.Mail))
                .ForMember(d => d.Number, opt => opt.MapFrom(s => s.CustomerContactDetail.TelephoneNumbers))
                .ForMember(d => d.Country, opt => opt.MapFrom(s => s.Address.Country))
                .ForMember(d => d.Locality, opt => opt.MapFrom(s => s.Address.Locality))
                .ForMember(d => d.Street, opt => opt.MapFrom(s => s.Address.Street))
                .ForMember(d => d.PostCode, opt => opt.MapFrom(s => s.Address.PostCode))
                .ForMember(d => d.NumberOfLocal, opt => opt.MapFrom(s => s.Address.NumberOfLocal))
                .ForMember(d => d.NumberOfAccommodation, opt => opt.MapFrom(s => s.Address.NumberOfAccommodation))
                .ReverseMap();
        }
    }

    public class NewCustomerValidation : AbstractValidator<NewCustomerVm>
    {
        public NewCustomerValidation()
        {
            RuleFor(c => c.FirstName).NotNull().WithMessage("First Name can not be null")
                .MaximumLength(20).WithMessage("First Name can not be create with more than 20 characters ")
                .MinimumLength(2).WithMessage("First Name can not be create with less than 2 characters ");

            RuleFor(c => c.LastName).NotNull().WithMessage("Last Name can not be null")
               .MaximumLength(20).WithMessage("Last Name can not be create with more than 20 characters ")
               .MinimumLength(2).WithMessage("Last Name can not be create with less than 2 characters ");

            RuleFor(c => c.Pesel).NotNull().WithMessage("Pesel can not be null")
               .Length(11).WithMessage("Pasel must have 11 characters");

            RuleFor(c => c.Country).NotNull().WithMessage("Country can not be null")
               .MaximumLength(20).WithMessage("Country can not be create with more than 20 characters ")
               .MinimumLength(2).WithMessage("Country can not be create with less than 2 characters ");

            RuleFor(c => c.Mail).NotNull().WithMessage("Mail can not be null")
                .EmailAddress().WithMessage("Wrong e-mail address");

            RuleFor(c => c.Password).NotNull().WithMessage("Password can not be null");



        }
    }
}
