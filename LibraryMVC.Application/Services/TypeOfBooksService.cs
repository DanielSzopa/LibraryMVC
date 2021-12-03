using AutoMapper;
using AutoMapper.QueryableExtensions;
using LibraryMVC.Domain;
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
        public void UpdateTypeOfBook(TypeOfBookVm model)
        {
            var typeOfBook = _mapper.Map<TypeOfBook>(model);
            _typeOfBookRepository.UpdateTypeOfBook(typeOfBook);
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

        public BookListVm GetBooksByTypeOfBookId(int id)
        {
            var books = _typeOfBookRepository.GetAllBooksByTypeOfBookId(id)
                .ProjectTo<BookForListVm>(_mapper.ConfigurationProvider).ToList();

            var result = new BookListVm
            {
                ListOfBookForList = books
            };
            return result;
        }
        public TypeOfBookVm GetTypeOfBookById(int id)
        {
            var typeOfBook = _typeOfBookRepository.GetTypeOfBookById(id);
            var typeOfBookVm = _mapper.Map<TypeOfBookVm>(typeOfBook);
            return typeOfBookVm;
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
