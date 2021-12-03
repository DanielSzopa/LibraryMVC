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
        int EditAuthor(AuthorDetailsVm model);
        void ChangeAuthorBeforeDelete(int id);
        NewAuthorVm GetAuthorForEdit(int id);
        string GetAuthorFullName(int id);
        IQueryable<Author> GetAllAuthors();       
        AuthorListVm GetAllAuthorToList(int pageNumber, int pageSize, string searchString);
        AuthorDetailsVm SetAuthorDetails(Author author);
        AuthorDetailsVm GetAuthorDetailsByAuthorId(int id);
        AuthorDetailsVm GetAuthorDetailsByBookId(int id);

    }
}
