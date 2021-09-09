using LibraryMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryMVC.Application
{
    public interface IPublisherService
    {
        void AddPublisher(PublisherVm model);
        void DeletePublisher(int id);
        void ChangePublisherBeforeDelete(int id);
        PublisherVm GetPublisherById(int id);
        PublisherListVm GetAllPublishersToList();        
    }
}
