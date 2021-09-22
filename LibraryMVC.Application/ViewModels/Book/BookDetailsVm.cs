using AutoMapper;
using LibraryMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryMVC.Application
{
    public class BookDetailsVm : IMapFrom<Book>
    {
        public int Id { get; set; }
        public string Title { get; set; }       
        public DateTime DateOfRelease { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
        public string Publisher { get; set; }
        public string Category { get; set; }
        public string TypeOfBook { get; set; }
        public string Author { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<Book, BookDetailsVm>()
                .ForMember(d => d.Publisher, opt => opt.MapFrom(s => s.Publisher.Name))
                .ForMember(d => d.Category, opt => opt.MapFrom(s => s.Category.Name))
                .ForMember(d => d.TypeOfBook, opt => opt.MapFrom(s => s.TypeOfBook.Name))
                .ForMember(d => d.Author, opt => opt.MapFrom(s => s.Author.FirstName + " " + s.Author.LastName));
        }
    }
}
