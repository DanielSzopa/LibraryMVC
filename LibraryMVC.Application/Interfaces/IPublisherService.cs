using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryMVC.Application
{
    public interface IPublisherService
    {
        void AddPublisher(PublisherVm model);
        PublisherListVm GetAllPublishersToList();        
    }
}
