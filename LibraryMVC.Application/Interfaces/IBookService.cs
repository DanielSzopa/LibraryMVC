using LibraryMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LibraryMVC.Application
{
    public interface IBookService 
    {
        int AddBook(NewBookVm model);
        void DeleteBook(int id);
        void UpdateBook(NewBookVm model);
        int GetExcludeRecordsToPagination(int pageNumber, int pageSize);
        List<T> ReturnRecordsToShow<T>(int pageNumber, int pageSize, List<T> list);
        NewBookVm GetBookForEdit(int id);
        Book GetBookById(int id);
        BookDetailsVm GetBookDetails(int bookId);
        BookListVm GetAllBooksToList(int pageNumber, int pageSize);         
        IQueryable<CategoryVm> GetBookCategories();
        IQueryable<PublisherVm> GetBookPublishers();
        IQueryable<TypeOfBookVm> GetBookTypeOfBooks();
        NewBookVm SetParametersToVm(NewBookVm model);
        AuthorDetailsVm GetAuthorDetailsByBookId(int id);
        IQueryable<Author> GetAllAuthors();
        IQueryable<AuthorVm> GetAuthorsToSelectList();
        AuthorListVm GetAllAuthorToList(int pageNumber, int pageSize);
        int AddAuthor(NewAuthorVm model);
        void DeleteAuthor(int id);
        CategoryListVm GetAllCategoriesToList();
        TypeOfBookListVm GetAllTypeOfBooksToList();
        PublisherListVm GetAllPublishersToList();

    }
}
