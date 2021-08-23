using AutoMapper;
using LibraryMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryMVC.Application
{
    public class BookForListVm : IMapFrom<Book>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string TypeOfBook { get; set; }
        public string Publisher { get; set; }
        public string Category { get; set; }
        public string Status { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Book, BookForListVm>()
                .ForMember(b => b.TypeOfBook, x => x.MapFrom(x => x.TypeOfBook.Name))
                .ForMember(b => b.Publisher, x => x.MapFrom(x => x.Publisher.Name))
                .ForMember(b => b.Category, x => x.MapFrom(x => x.Category.Name))             
                .ForMember(b => b.Author, x => x.MapFrom(x => x.Author.FirstName + " " + x.Author.LastName));              
        }
    }
}
