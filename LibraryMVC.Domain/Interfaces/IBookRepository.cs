using LibraryMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryMVC.Domain.Interfaces
{
    public interface IBookRepository
    {
        int AddBook(Book book);
        void DeleteBook(int id);
        void UpdateBook(Book book);
        Book GetBookById(int bookId);
        IQueryable<Book> GetAllBooks();     
        IQueryable<Category> GetAllCategories();
        IQueryable<TypeOfBook> GetAllTypeOfBooks();
        IQueryable<Publisher> GetAllPublishers();
        IQueryable<Author> GetAllAuthors();
        IQueryable<Book> GetAllBooksByAuthor(int authorId);
        Author GetAuthorByBookId(int bookId);
        int CountAuthorsBooks(int id);
        int AddAuthor(Author author);




    }
}
