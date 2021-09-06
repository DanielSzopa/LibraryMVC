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
        IQueryable<Publisher> GetAllPublishers();
    }
}
