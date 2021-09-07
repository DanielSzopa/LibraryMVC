using LibraryMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryMVC.Domain.Interfaces
{
    public interface IPublisherRepository
    {
        void DeletePublisher(int id);
        void AddPublisher(Publisher model);        
        IQueryable<Publisher> GetAllPublishers();
        void ChangePublisherNameToOther(int id);
    }
}
