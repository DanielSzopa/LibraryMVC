using AutoMapper;
using LibraryMVC.Domain;

namespace LibraryMVC.Application
{
    public class BookDetailsForReservationVm : IMapFrom<Book>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Book, BookDetailsForReservationVm>()
                .ForMember(b => b.Author, opt => opt.MapFrom(b => b.Author.FirstName + " " + b.Author.LastName));
        }
    }
}
