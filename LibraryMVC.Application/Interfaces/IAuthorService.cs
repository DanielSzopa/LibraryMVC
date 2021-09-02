using LibraryMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryMVC.Application
{
    public interface IAuthorService
    {
        int AddAuthor(NewAuthorVm model);
        void DeleteAuthor(int id);     
        IQueryable<Author> GetAllAuthors();       
        AuthorListVm GetAllAuthorToList(int pageNumber, int pageSize);
        AuthorDetailsVm SetAuthorDetails(Author author);
        AuthorDetailsVm GetAuthorDetailsByAuthorId(int id);
        AuthorDetailsVm GetAuthorDetailsByBookId(int id);

    }
}
