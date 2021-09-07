using LibraryMVC.Domain.Interfaces;
using LibraryMVC.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryMVC.Infrastructure
{
    public class BookRepository : IBookRepository
    {
        private readonly Context _context;
        public BookRepository(Context context)
        {
            _context = context;
        }

        public int AddBook(Book book)
        {
            _context.Add(book);
            _context.SaveChanges();
            return book.Id;
        }

        public void DeleteBook(int id)
        {
            var book = _context.Books.Find(id);
            if(book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }

        public void UpdateBook(Book book)
        {
            _context.Attach(book);
            _context.Entry(book).Property("Title").IsModified = true;
            _context.Entry(book).Property("Description").IsModified = true;
            _context.Entry(book).Property("DateOfRelease").IsModified = true;
            _context.Entry(book).Property("AuthorId").IsModified = true;
            _context.Entry(book).Property("CategoryId").IsModified = true;
            _context.Entry(book).Property("PublisherId").IsModified = true;
            _context.Entry(book).Property("TypeOfBookId").IsModified = true;
            _context.SaveChanges();
        }

        public Book GetBookById(int bookId)
        {
            var book = _context.Books
                .Include(a => a.Author)
                .Include(p => p.Publisher)
                .Include(c => c.Category)
                .Include(t => t.TypeOfBook)
                //  .Include(s=>s.Status)
                .FirstOrDefault(b => b.Id == bookId);      

            return book;
        }

        public IQueryable<Book> GetAllBooks()
        {
            var books = _context.Books;
            return books;
        }     
    }
}
