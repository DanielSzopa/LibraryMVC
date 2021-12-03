using AutoMapper;
using LibraryMVC.Domain;
using System.Collections.Generic;

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
