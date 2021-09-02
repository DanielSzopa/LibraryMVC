using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryMVC.Application
{
    public interface ITypeOfBookService
    {
        TypeOfBookListVm GetAllTypeOfBooksToList();
    }
}
