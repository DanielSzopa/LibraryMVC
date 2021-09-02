using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

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
            services.AddTransient<IPaginationService, PaginationService>();
            
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddTransient<IValidator<NewBookVm>, NewBookVmValidation>();
            services.AddTransient<IValidator<NewAuthorVm>, NewAuthorVmValidation>();
            services.AddTransient<IValidator<CategoryVm>, NewCategoryVmValidation>();

            return services;
        }
    }
}
