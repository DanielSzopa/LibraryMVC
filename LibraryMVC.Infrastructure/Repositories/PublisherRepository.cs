using LibraryMVC.Domain;
using LibraryMVC.Domain.Interfaces;
using LibraryMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryMVC.Infrastructure
{
    public class PublisherRepository : IPublisherRepository
    {
        private readonly Context _context;
        public PublisherRepository(Context context)
        {
            _context = context;
        }
        public IQueryable<Publisher> GetAllPublishers()
        {
            var publishers = _context.Publishers;
            return publishers;
        }
    }
}
