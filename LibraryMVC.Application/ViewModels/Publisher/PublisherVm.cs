using AutoMapper;
using LibraryMVC.Domain;

namespace LibraryMVC.Application
{
    public class PublisherVm : IMapFrom<Publisher>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfBooks { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Publisher, PublisherVm>()
                .ReverseMap();
        }
    }   
}
