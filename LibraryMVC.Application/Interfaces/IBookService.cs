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
        void AddCategory(CategoryVm model);            
        NewBookVm GetBookForEdit(int id);
        Book GetBookById(int id);
        BookDetailsVm GetBookDetails(int bookId);
        BookListVm GetAllBooksToList(int pageNumber, int pageSize);         
        IQueryable<CategoryVm> GetBookCategories();
        IQueryable<PublisherVm> GetBookPublishers();
        IQueryable<TypeOfBookVm> GetBookTypeOfBooks();
        IQueryable<AuthorVm> GetAuthorsToSelectList();
        NewBookVm SetParametersToVm(NewBookVm model);      
        CategoryListVm GetAllCategoriesToList();
        TypeOfBookListVm GetAllTypeOfBooksToList();
        PublisherListVm GetAllPublishersToList();

    }
}
