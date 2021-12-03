using AutoMapper;
using LibraryMVC.Domain;

namespace LibraryMVC.Application
{
    public class AuthorVm : IMapFrom<Author>
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Author, AuthorVm>()
                .ForMember(d => d.FullName, opt => opt.MapFrom(s => s.FirstName + " " + s.LastName));
        }
    }
}
