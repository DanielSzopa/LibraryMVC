namespace LibraryMVC.Application
{
    public interface ITypeOfBookService
    {
        void AddTypeOfBook(TypeOfBookVm model);
        void UpdateTypeOfBook(TypeOfBookVm model);
        void DeleteTypeOfBook(int id);
        void ChangeTypeOfBookBeforeDelete(int id);
        BookListVm GetBooksByTypeOfBookId(int id);
        TypeOfBookVm GetTypeOfBookById(int id);
        TypeOfBookListVm GetAllTypeOfBooksToList();
    }
}
