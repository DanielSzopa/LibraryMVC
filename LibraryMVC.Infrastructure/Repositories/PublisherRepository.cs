using LibraryMVC.Domain;
using System.Linq;

namespace LibraryMVC.Infrastructure
{
    public class PublisherRepository : IPublisherRepository
    {
        private readonly Context _context;
        public PublisherRepository(Context context)
        {
            _context = context;
        }

        public void AddPublisher(Publisher model)
        {
            _context.Publishers.Add(model);
            _context.SaveChanges();
        }

        public void UpdatePublisher(Publisher model)
        {
            _context.Attach(model);
            _context.Entry(model).Property("Name").IsModified = true;
            _context.SaveChanges();
        }

        public void DeletePublisher(int id)
        {
            var publisher = _context.Publishers.Find(id);
            if (publisher != null)
            {
                _context.Publishers.Remove(publisher);
                _context.SaveChanges();
            }
        }

        public void ChangePublisherNameToOther(int id)
        {
            var books = _context.Books.Where(b => b.PublisherId == id)
                 .ToList();

                books.ForEach(b=>b.PublisherId = 1);
            _context.SaveChanges();
        }

        public int CountBooksOfPublisher(int id)
        {
            var numberOfBooks = _context.Books.Where(b => b.PublisherId == id).Count();
            return numberOfBooks;
        }

        public Publisher GetPublisherById(int id)
        {
            var publisher = _context.Publishers.Find(id);
            return publisher;
        }
        public IQueryable<Book> GetAllBooksByPublisherId(int id)
        {
            var publishers = _context.Books.Where(b => b.PublisherId == id);
            return publishers;
        }

        public IQueryable<Publisher> GetAllPublishers()
        {
            var publishers = _context.Publishers;
            return publishers;
        }

        
    }
}
