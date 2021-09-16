using AutoMapper;
using AutoMapper.QueryableExtensions;
using LibraryMVC.Domain.Interfaces;
using LibraryMVC.Domain.Models;
using System.Linq;
using System.Security.Policy;

namespace LibraryMVC.Application
{
    public class PublisherService : IPublisherService
    {
        private readonly IPublisherRepository _publisherRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        public PublisherService(IPublisherRepository publisherRepository, IMapper mapper, IBookRepository bookRepository)
        {
            _publisherRepository = publisherRepository;
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public void AddPublisher(PublisherVm model)
        {
            var publisher = _mapper.Map<LibraryMVC.Domain.Models.Publisher>(model);           
            _publisherRepository.AddPublisher(publisher);
        }

        public void UpdatePublisher(PublisherVm model)
        {
            var publisher = _mapper.Map<LibraryMVC.Domain.Models.Publisher>(model);
            _publisherRepository.UpdatePublisher(publisher);
        }

        public void DeletePublisher(int id)
        {
            ChangePublisherBeforeDelete(id);
            _publisherRepository.DeletePublisher(id);
        }

        public void ChangePublisherBeforeDelete(int id)
        {           
                _publisherRepository.ChangePublisherNameToOther(id);                                   
        }

        public BookListVm GetBooksByPublisherId(int id)
        {
            var books = _publisherRepository.GetAllBooksByPublisherId(id)
                .ProjectTo<BookForListVm>(_mapper.ConfigurationProvider).ToList();

            var result = new BookListVm
            {
                ListOfBookForList = books
            };
            return result;
        }

        public PublisherVm GetPublisherById(int id)
        {
            var publisher = _publisherRepository.GetPublisherById(id);
            var publisherVm = _mapper.Map<PublisherVm>(publisher);
            return publisherVm;
        }

        public PublisherListVm GetAllPublishersToList()
        {
            var publishers = _publisherRepository.GetAllPublishers().ProjectTo<PublisherVm>(_mapper.ConfigurationProvider)
                .ToList();
            foreach(var publisherVm in publishers)
            {
                publisherVm.NumberOfBooks = _publisherRepository.CountBooksOfPublisher(publisherVm.Id);
            }
            
            var result = new PublisherListVm
            {
                Publishers = publishers
            };

            return result;
        }     
    }
}
