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
        public IQueryable<TypeOfBook> GetAllTypeOfBooks()
        {
            var typeOfBooks = _context.TypeOfBooks;
            return typeOfBooks;
        }
    }
}
