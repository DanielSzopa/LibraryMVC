using AutoMapper;

namespace LibraryMVC.Application
{
    public class BookFullNameVm : IMapFrom<BookForListVm>
    {
        public int Id { get; set; }
        public string BookFullName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<BookForListVm, BookFullNameVm>()
                .ForMember(b => b.BookFullName, opt => opt.MapFrom(b => b.Title + " " + b.Author));
        }
    }
}
