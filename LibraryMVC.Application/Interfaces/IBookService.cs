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
        NewBookVm GetBookForEdit(int id);
        Book GetBookById(int id);
        BookDetailsVm GetBookDetails(int bookId);
        BookListVm GetAllBooksToList(int pageNumber, int pageSize, string searchString, string filter, int categoryId, int publisherId, int typeOfBookId, int authorId);         
        IQueryable<CategoryVm> GetCategoriesToSelectList();
        IQueryable<PublisherVm> GetPublishersToSelectList();
        IQueryable<TypeOfBookVm> GetTypeOfBooksToSelectList();
        IQueryable<AuthorVm> GetAuthorsToSelectList();
        NewBookVm SetParametersToVm(NewBookVm model);                  

    }
}
