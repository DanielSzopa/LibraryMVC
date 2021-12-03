using System.Linq;

namespace LibraryMVC.Domain
{
    public interface IBookRepository
    {
        int AddBook(Book book);
        void DeleteBook(int id);
        void UpdateBook(Book book);
        Book GetBookById(int bookId);
        IQueryable<Book> GetAllBooks();
        IQueryable<Book> GetAllActiveBooks();
        void ChangeStatusOfBook(int id, Status status);
    }
}
