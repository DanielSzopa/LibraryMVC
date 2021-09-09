using LibraryMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryMVC.Domain.Interfaces
{
    public interface IPublisherRepository
    {     
        void AddPublisher(Publisher model);
        void DeletePublisher(int id);
        void ChangePublisherNameToOther(int id);
        int CountBooksOfPublisher(int id);
        IQueryable<Publisher> GetAllPublishers();
        
    }
}
