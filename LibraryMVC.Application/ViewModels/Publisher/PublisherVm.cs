using AutoMapper;
using FluentValidation;
using LibraryMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryMVC.Application
{
    public class PublisherVm : IMapFrom<Publisher>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Publisher, PublisherVm>()
                .ReverseMap();
        }
    }

    public class PublisherVmValidation : AbstractValidator<PublisherVm>
    {
        public PublisherVmValidation()
        {
            RuleFor(p => p.Id).NotNull();
            RuleFor(p => p.Name)
                .NotNull().WithMessage("This field can't be null");
            RuleFor(p => p.Name).MinimumLength(3).WithMessage("This field have to have more than 3 characters");
        }
    }
}
