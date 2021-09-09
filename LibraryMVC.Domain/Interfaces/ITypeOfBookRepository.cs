using LibraryMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryMVC.Domain.Interfaces
{
    public interface ITypeOfBookRepository
    {
        void DeleteTypeOfBook(int id);
        void ChangeTypeOfBookNameToOther(int id);
        int CountBooksOfTypeOfBook(int id);
        IQueryable<TypeOfBook> GetAllTypeOfBooks();
    }
}
