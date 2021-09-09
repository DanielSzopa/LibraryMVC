using AutoMapper;
using AutoMapper.QueryableExtensions;
using LibraryMVC.Domain.Interfaces;
using LibraryMVC.Domain.Models;
using System.Linq;

namespace LibraryMVC.Application
{
    public class TypeOfBookService : ITypeOfBookService
    {
        private readonly ITypeOfBookRepository _typeOfBookRepository;
        private readonly IMapper _mapper;
        public TypeOfBookService(ITypeOfBookRepository typeOfBookRepository, IMapper mapper)
        {
            _typeOfBookRepository = typeOfBookRepository;
            _mapper = mapper;
        }
        public void AddTypeOfBook(TypeOfBookVm model)
        {
            var typeOfBook = _mapper.Map<TypeOfBook>(model);
            _typeOfBookRepository.AddTypeOfBook(typeOfBook);
        }
        public void DeleteTypeOfBook(int id)
        {
            ChangeTypeOfBookBeforeDelete(id);
            _typeOfBookRepository.DeleteTypeOfBook(id);
        }
        public void ChangeTypeOfBookBeforeDelete(int id)
        {
            _typeOfBookRepository.ChangeTypeOfBookNameToOther(id);
        }
        public TypeOfBookListVm GetAllTypeOfBooksToList()
        {
            var typeOfBooks = _typeOfBookRepository.GetAllTypeOfBooks().ProjectTo<TypeOfBookVm>(_mapper.ConfigurationProvider)
               .ToList();
            foreach(var typeOfBookVm in typeOfBooks)
            {
                typeOfBookVm.NumberOfBooks = _typeOfBookRepository.CountBooksOfTypeOfBook(typeOfBookVm.Id);
            }

            var result = new TypeOfBookListVm
            {
                TypesOfBooks = typeOfBooks
            };

            return result;
        }
        
    }
}
