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

        public void ChangePublisherBeforeDelete(int id)
        {           
                _publisherRepository.ChangePublisherNameToOther(id);                                   
        }

        public void DeletePublisher(int id)
        {                            
            ChangePublisherBeforeDelete(id);
            _publisherRepository.DeletePublisher(id);           
        }
        public PublisherListVm GetAllPublishersToList()
        {
            var publishers = _publisherRepository.GetAllPublishers().ProjectTo<PublisherVm>(_mapper.ConfigurationProvider)
                .ToList();

            var result = new PublisherListVm
            {
                Publishers = publishers
            };

            return result;
        }
    }
}
