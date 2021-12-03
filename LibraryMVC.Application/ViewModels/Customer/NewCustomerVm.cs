using AutoMapper;
using FluentValidation;
using LibraryMVC.Domain;

namespace LibraryMVC.Application
{
    public class NewCustomerVm : IMapFrom<Customer>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Pesel { get; set; }
        public CustomerContactDetailsVm CustomerContactDetail {get; set;}
        public AddressVm Address { get; set;}
        public string Password { get; set; }
        public bool isLocalAccount { get; set; }
        public string UserId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Customer, NewCustomerVm>()
                .ReverseMap();
        }
    }

    public class NewCustomerValidation : AbstractValidator<NewCustomerVm>
    {
        public NewCustomerValidation()
        {
            RuleFor(c => c.FirstName).NotNull().WithMessage("First Name can not be null")
                .MaximumLength(20).WithMessage("First Name can not be create with more than 20 characters ")
                .MinimumLength(2).WithMessage("First Name can not be create with less than 2 characters ");

            RuleFor(c => c.LastName).NotNull().WithMessage("Last Name can not be null")
               .MaximumLength(20).WithMessage("Last Name can not be create with more than 20 characters ")
               .MinimumLength(2).WithMessage("Last Name can not be create with less than 2 characters ");

            RuleFor(c => c.Pesel).NotNull().WithMessage("Pesel can not be null")
               .Length(11).WithMessage("Pasel must have 11 characters");

            RuleFor(c => c.CustomerContactDetail.Mail).NotNull().WithMessage("Mail can not be null")
                .EmailAddress().WithMessage("Wrong e-mail address");

            RuleFor(c => c.Password).NotNull().WithMessage("Password can not be null");
              


        }
    }
}
