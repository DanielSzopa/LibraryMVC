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
        void ChangeStatusOfBook(int id, Status status);
    }
}
