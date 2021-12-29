using AutoMapper;
using LibraryMVC.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryMVC.Application
{
    public class RentalForListVm : IMapFrom<Rental>
    {
        public int Id { get; set; }
        public string Customer { get; set; }
        public string Book { get; set; }
        public int CustomerId { get; set; }
        public int BookId { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Rental, RentalForListVm>()
                .ForMember(d => d.Book, opt => opt.MapFrom(s => s.Book.Title))
                .ForMember(d => d.Customer, opt => opt.MapFrom(s => $"{s.Customer.FirstName} {s.Customer.LastName}"));
        }
    }
}
