using LibraryMVC.Domain;
using LibraryMVC.Domain.Interfaces;
using LibraryMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryMVC.Infrastructure
{
    public class TypeOfBookRepository : ITypeOfBookRepository
    {
        private readonly Context _context;
        public TypeOfBookRepository(Context context)
        {
            _context = context;
        }
        public void DeleteTypeOfBook(int id)
        {
            var typeofbook = _context.TypeOfBooks.Find(id);
            if (typeofbook != null)
            {
                _context.TypeOfBooks.Remove(typeofbook);
                _context.SaveChanges();
            }
        }
        public void ChangeTypeOfBookNameToOther(int id)
        {
            var books = _context.Books.Where(b => b.TypeOfBookId == id)
                 .ToList();

            books.ForEach(b => b.TypeOfBookId = 1);
            _context.SaveChanges();
        }
        public int CountBooksOfTypeOfBook(int id)
        {
            var numberOfBooks = _context.Books.Where(b => b.TypeOfBookId == id).Count();
            return numberOfBooks;
        }
        public IQueryable<TypeOfBook> GetAllTypeOfBooks()
        {
            var typeOfBooks = _context.TypeOfBooks;
            return typeOfBooks;
        }
    }
}
