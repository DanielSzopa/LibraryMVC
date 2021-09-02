using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryMVC.Application
{
    public interface IPublisherService
    {
        PublisherListVm GetAllPublishersToList();
    }
}
