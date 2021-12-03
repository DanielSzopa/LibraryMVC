using AutoMapper;
using LibraryMVC.Domain;

namespace LibraryMVC.Application
{
    public class AuthorDetailsVm : IMapFrom<Author>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Biography { get; set; }
        public int IdCurrentBook { get; set; }
        public int BooksNumber { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Author, AuthorDetailsVm>()
                .ReverseMap();
        }
       
    }
}
