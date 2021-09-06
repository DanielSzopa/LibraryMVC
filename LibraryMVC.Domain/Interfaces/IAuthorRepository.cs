using LibraryMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryMVC.Domain.Interfaces
{
    public interface IAuthorRepository
    {
        int AddAuthor(Author author);
        void DeleteAuthor(int id);
        int EditAuthor(Author author);
        int CountAuthorsBooks(int id);
        IQueryable<Author> GetAllAuthors();
        IQueryable<Book> GetAllBooksByAuthor(int authorId);
        Author GetAuthorById(int id);
        Author GetAuthorByBookId(int bookId);

    }
}
