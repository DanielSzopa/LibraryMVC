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

        public void AddPublisher(Publisher model)
        {
             _context.Publishers.Add(model);
            _context.SaveChanges();
        }

        public void ChangePublisherNameToOther(int id)
        {
            var books = _context.Books.Where(b => b.PublisherId == id)
                 .ToList();

                books.ForEach(b=>b.PublisherId = 1);
            _context.SaveChanges();
        }

        public void DeletePublisher(int id)
        {
            var publisher = _context.Publishers.Find(id);
            if(publisher != null)
            {
                _context.Publishers.Remove(publisher);
                _context.SaveChanges();
            }
        }

        public IQueryable<Publisher> GetAllPublishers()
        {
            var publishers = _context.Publishers;
            return publishers;
        }
    }
}
