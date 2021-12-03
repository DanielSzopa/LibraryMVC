using AutoMapper;
using LibraryMVC.Domain;

namespace LibraryMVC.Application
{
    public class TypeOfBookVm: IMapFrom<TypeOfBook>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfBooks { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TypeOfBook, TypeOfBookVm>()
                .ReverseMap();
        }
    }
}
