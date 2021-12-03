using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace LibraryMVC.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<IAuthorService, AuthorService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IPublisherService, PublisherService>();
            services.AddTransient<ITypeOfBookService, TypeOfBookService>();
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<IRentalService,RentalService>();
            services.AddTransient<IReservationService,ReservationService>();
            services.AddTransient<IPaginationService, PaginationService>();
            services.AddTransient<IUserService, UserService>();
           
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddTransient<IValidator<NewBookVm>, NewBookVmValidation>();
            services.AddTransient<IValidator<NewAuthorVm>, NewAuthorVmValidation>();
            services.AddTransient<IValidator<NewCustomerVm>, NewCustomerValidation>();

            return services;
        }
    }
}
