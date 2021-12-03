using AutoMapper;
using LibraryMVC.Domain;
using System;

namespace LibraryMVC.Application
{
    public class ReservationDetailsVm : IMapFrom<Reservation>
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int CustomerId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPesel { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Reservation, ReservationDetailsVm>()
                .ForMember(r => r.Title, opt => opt.MapFrom(x => x.Book.Title))
                .ForMember(r => r.Author, opt => opt.MapFrom(x => x.Book.Author.FirstName + " " + x.Book.Author.LastName))
                .ForMember(r => r.CustomerFirstName, opt => opt.MapFrom(x => x.Customer.FirstName))
                .ForMember(r => r.CustomerLastName, opt => opt.MapFrom(x => x.Customer.LastName))
                .ForMember(r => r.CustomerEmail, opt => opt.MapFrom(x => x.Customer.CustomerContactDetail.Mail))
                .ForMember(r => r.CustomerPesel, opt => opt.MapFrom(x => x.Customer.Pesel))                             
                .ReverseMap();
        }
    }
}
