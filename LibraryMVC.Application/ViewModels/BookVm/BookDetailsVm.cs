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
                .ForMember(s => s.Publisher, opt => opt.MapFrom(d => d.Publisher.Name))
                .ForMember(s => s.Category, opt => opt.MapFrom(d => d.Category.Name))
                .ForMember(s => s.TypeOfBook, opt => opt.MapFrom(d => d.TypeOfBook.Name))
                .ForMember(s => s.Author, opt => opt.MapFrom(d => d.Author.FirstName + " " + d.Author.LastName));
        }
    }
}
