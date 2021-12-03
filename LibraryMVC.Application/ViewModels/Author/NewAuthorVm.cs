using AutoMapper;
using FluentValidation;
using LibraryMVC.Domain;

namespace LibraryMVC.Application
{
    public class NewAuthorVm : IMapFrom<Author>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Biography { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewAuthorVm, Author>()
                .ReverseMap();
        }
    }

    public class NewAuthorVmValidation : AbstractValidator<NewAuthorVm>
    {
        public NewAuthorVmValidation()
        {
            RuleFor(a => a.FirstName).NotNull().WithMessage("Your First Name can not be null"); 
            RuleFor(a => a.LastName).NotNull().WithMessage("Your Last Name can not be null");           
        }
    }


}
