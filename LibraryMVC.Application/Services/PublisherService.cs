using AutoMapper;
using AutoMapper.QueryableExtensions;
using LibraryMVC.Domain.Interfaces;
using System.Linq;

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
