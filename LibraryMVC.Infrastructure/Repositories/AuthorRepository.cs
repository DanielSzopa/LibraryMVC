using LibraryMVC.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LibraryMVC.Infrastructure
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly Context _context;
        public AuthorRepository(Context context)
        {
            _context = context;
        }
        public int AddAuthor(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
            return author.Id;
        }

        public void DeleteAuthor(int id)
        {
            var author = _context.Authors.Find(id);
            if (author != null)
            {
                _context.Authors.Remove(author);
                _context.SaveChanges();
            }
        }

        public int EditAuthor(Author author)
        {
            _context.Attach(author);
            _context.Entry(author).Property("FirstName").IsModified = true;
            _context.Entry(author).Property("LastName").IsModified = true;
            _context.Entry(author).Property("Biography").IsModified = true;
            _context.SaveChanges();
            return author.Id;
        }

        public int CountAuthorsBooks(int id)
        {
            var countBooks = _context.Books.Where(a => a.AuthorId == id).Count();

            return countBooks;
        }

        public void ChangeAuthorNameToNone(int id)
        {
            var authors = _context.Books.Where(b => b.AuthorId == id)
                .ToList();

            authors.ForEach(b => b.AuthorId = 1);
            _context.SaveChanges();
        }

        public IQueryable<Author> GetAllAuthors()
        {
            return _context.Authors;
        }

        public IQueryable<Book> GetAllBooksByAuthor(int authorId)
        {
            var books = _context.Books.Where(b => b.AuthorId == authorId);
            return books;
        }

        public Author GetAuthorById(int id)
        {
            var author = _context.Authors.FirstOrDefault(a => a.Id == id);
            return author;
        }

        public Author GetAuthorByBookId(int bookId)
        {
            var author = _context.Books
                .Include(a => a.Author)
                .FirstOrDefault(b => b.Id == bookId).Author;

            return author;
        }      
    }
}
