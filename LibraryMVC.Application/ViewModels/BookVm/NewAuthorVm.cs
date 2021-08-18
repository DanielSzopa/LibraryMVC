using FluentValidation;
using LibraryMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryMVC.Application.ViewModels.BookVm
{
    public class NewAuthorVm : IMapFrom<Author>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
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
