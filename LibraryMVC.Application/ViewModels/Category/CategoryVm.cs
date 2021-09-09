using AutoMapper;
using FluentValidation;
using LibraryMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryMVC.Application
{
    public class CategoryVm : IMapFrom<Category>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfBooks { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Category, CategoryVm>()
                .ReverseMap();
        }       
    }
    public class NewCategoryVmValidation : AbstractValidator<CategoryVm>
    {
        public NewCategoryVmValidation()
        {
            RuleFor(c => c.Id).NotNull();
            RuleFor(c => c.Name)
                .NotNull().WithMessage("This field can't be null");
                

        }
    }
}
