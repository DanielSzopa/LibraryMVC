using AutoMapper;
using FluentValidation;
using LibraryMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryMVC.Application
{
    public class NewBookVm : IMapFrom<Book>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateOfRelease { get; set; }   
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
        public int PublisherId { get; set; }
        public int TypeOfBookId { get; set; }
        public List<AuthorVm> Authors { get; set; }
        public List<CategoryVm> Categories { get; set; }
        public List<PublisherVm> Publishers { get; set; }
        public List<TypeOfBookVm> TypeOfBooks { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewBookVm, Book>()
                .ReverseMap();
              
                

        }

    }
    public class NewBookVmValidation : AbstractValidator<NewBookVm> 
    {
        public NewBookVmValidation()
        {
            RuleFor(b => b.Id).NotNull();
            RuleFor(b => b.Authors).NotNull();
            RuleFor(b => b.Title).NotNull().WithMessage("This field can't be null");
            RuleFor(b => b.Title).MinimumLength(2).WithMessage("Title can't be create with less than 2 characters");
            RuleFor(b => b.Description).MaximumLength(250).WithMessage("Description can't be more than 250 characters");
        }
    }


}
