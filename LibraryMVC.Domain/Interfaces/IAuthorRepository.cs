using System.Linq;

namespace LibraryMVC.Domain
{
    public interface IAuthorRepository
    {
        int AddAuthor(Author author);
        void DeleteAuthor(int id);
        int EditAuthor(Author author);
        int CountAuthorsBooks(int id);
        void ChangeAuthorNameToNone(int id);
        IQueryable<Author> GetAllAuthors();
        IQueryable<Book> GetAllBooksByAuthor(int authorId);
        Author GetAuthorById(int id);
        Author GetAuthorByBookId(int bookId);

    }
}
