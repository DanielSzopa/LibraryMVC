﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryMVC.Application
{
    public interface ITypeOfBookService
    {
        void AddTypeOfBook(TypeOfBookVm model);
        void DeleteTypeOfBook(int id);
        void ChangeTypeOfBookBeforeDelete(int id);
        TypeOfBookListVm GetAllTypeOfBooksToList();
    }
}
