using LibraryMVC.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
                .FirstOrDefault(b => b.Id == bookId);      
            return book;
        }

        public IQueryable<Book> GetAllBooks()
        {
            var books = _context.Books;
            return books;
        }
        public IQueryable<Book> GetAllActiveBooks()
        {
            var books = _context.Books.Where(b => b.Status == Status.Active);
            return books;
        }

        public void ChangeStatusOfBook(int id, Status status)
        {
            var book = _context.Books.Find(id);

            book.Status = status;
            _context.SaveChanges();
        }

        public bool IsBookHaveThisStatus(int bookId, Status status)
        {
            var book = _context.Books
                .FirstOrDefault(b => b.Id == bookId);

            if (book.Status == status)
                return true;

            return false;
        }
    }
}
