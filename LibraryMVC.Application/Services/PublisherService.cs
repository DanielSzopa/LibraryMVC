using AutoMapper;
using AutoMapper.QueryableExtensions;
using LibraryMVC.Domain.Interfaces;
using System.Linq;
using System.Security.Policy;

namespace LibraryMVC.Application
{
    public class PublisherService : IPublisherService
    {
        private readonly IPublisherRepository _publisherRepository;
        private readonly IMapper _mapper;
        public PublisherService(IPublisherRepository publisherRepository, IMapper mapper)
        {
            _publisherRepository = publisherRepository;
            _mapper = mapper;
        }

        public void AddPublisher(PublisherVm model)
        {
            var publisher = _mapper.Map<LibraryMVC.Domain.Models.Publisher>(model);
            
            _publisherRepository.AddPublisher(publisher);
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
