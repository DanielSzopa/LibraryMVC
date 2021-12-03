using AutoMapper;
using LibraryMVC.Domain;
using System;

namespace LibraryMVC.Application
{
    public class ReservationForListVm : IMapFrom<Reservation>
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
            profile.CreateMap<Reservation, ReservationForListVm>()
                .ForMember(d => d.Customer, opt => opt.MapFrom(s => s.Customer.FirstName + " " + s.Customer.LastName))
                .ForMember(d => d.Book, opt => opt.MapFrom(s => s.Book.Title));
        }
    }
}
