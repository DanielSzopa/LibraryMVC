using AutoMapper;
using LibraryMVC.Domain.Models;

namespace LibraryMVC.Application
{
    public class CustomerForReservationVm : IMapFrom<Customer>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Pesel { get; set; }
        public string Mail { get; set; }     
        
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Customer, CustomerForReservationVm>()
                .ForMember(c => c.Mail, opt => opt.MapFrom(c => c.CustomerContactDetail.Mail));
        }
    }
}

