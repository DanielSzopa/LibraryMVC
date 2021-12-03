using AutoMapper;
using LibraryMVC.Domain;

namespace LibraryMVC.Application
{
    public class AuthorForListVm : IMapFrom<Author>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int NumberOfBooks { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Author, AuthorForListVm>();
                
        }
    }
}
