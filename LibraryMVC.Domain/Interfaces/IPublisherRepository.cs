using System.Linq;

namespace LibraryMVC.Domain
{
    public interface IPublisherRepository
    {
        void AddPublisher(Publisher model);
        void UpdatePublisher(Publisher model);
        void DeletePublisher(int id);
        void ChangePublisherNameToOther(int id);
        int CountBooksOfPublisher(int id);
        Publisher GetPublisherById(int id);
        IQueryable<Book> GetAllBooksByPublisherId(int id);
        IQueryable<Publisher> GetAllPublishers();
        
    }
}
