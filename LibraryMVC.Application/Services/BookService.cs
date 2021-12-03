using AutoMapper;
using AutoMapper.QueryableExtensions;
using LibraryMVC.Domain;
using System.Linq;


namespace LibraryMVC.Application
{
    public class BookService : IBookService
    {
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IPublisherRepository _publisherRepository;
        private readonly ITypeOfBookRepository _typeOfBookRepository;
        private readonly IPaginationService _paginationService;
        public BookService(IBookRepository bookRepository, 
            IAuthorRepository authorRepository, 
            IMapper mapper, 
            IPaginationService paginationService, ICategoryRepository categoryRepository, 
            IPublisherRepository publisherRepository, 
            ITypeOfBookRepository typeOfBookRepository)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _paginationService = paginationService;
            _authorRepository = authorRepository;
            _categoryRepository = categoryRepository;
            _publisherRepository = publisherRepository;
            _typeOfBookRepository = typeOfBookRepository;
        }

        public int AddBook(NewBookVm model)
        {
            var book = _mapper.Map<Book>(model);
            book.Status = Status.Active;

            return _bookRepository.AddBook(book);
        }

        public void DeleteBook(int id)
        {
            _bookRepository.DeleteBook(id);
        }

        public void UpdateBook(NewBookVm model)
        {
            var book = _mapper.Map<Book>(model);
            _bookRepository.UpdateBook(book);
        }    

        public NewBookVm GetBookForEdit(int id)
        {
            var book = _bookRepository.GetBookById(id);
            var bookVm = _mapper.Map<NewBookVm>(book); //błąd mapowania
            var model = SetParametersToVm(bookVm);
            return model;
        }

        public BookDetailsVm GetBookDetails(int bookId)
        {
            var book = _bookRepository.GetBookById(bookId);
            var bookDetailVm = _mapper.Map<BookDetailsVm>(book);

            return bookDetailVm;
        }

        public BookDetailsForReservationVm GetBookDetailsForReservation(int id)
        {
            var book = _bookRepository.GetBookById(id);
            var bookVm = _mapper.Map<BookDetailsForReservationVm>(book);

            return bookVm;
        }

        public BookListVm GetAllBooksToList(int pageNumber, int pageSize, string searchString, string filter, int filterId)
        {
            var books = default(IQueryable<Book>);

            switch (filter)
            {
                case "Category":
                    books = _categoryRepository.GetAllBooksByCategoryId(filterId).Where(b => b.Title.Contains(searchString));
                    break;
                case "Publisher":
                    books = _publisherRepository.GetAllBooksByPublisherId(filterId).Where(b => b.Title.Contains(searchString));
                    break;
                case "TypeOfBook":
                    books = _typeOfBookRepository.GetAllBooksByTypeOfBookId(filterId).Where(b => b.Title.Contains(searchString));
                    break;
                case "Author":
                    books = _authorRepository.GetAllBooksByAuthor(filterId).Where(b => b.Title.Contains(searchString));
                    break;
                default:
                    books = _bookRepository.GetAllBooks().Where(b => b.Title.Contains(searchString));
                    break;
            }
            
            var mappedBooks = books
                .ProjectTo<BookForListVm>(_mapper.ConfigurationProvider).ToList();

            var records = _paginationService.ReturnRecordsToShow<BookForListVm>(pageNumber, pageSize, mappedBooks);

            var result = new BookListVm()
            {
                ListOfBookForList = records,
                Count = mappedBooks.Count,
                PageSize = pageSize,
                PageNumber = pageNumber,
                SearchString = searchString,
                Filter = filter,
                FilterId = filterId

            };
            return result;
        }

        public IQueryable<BookForListVm> GetAllActiveBooks()
        {
            var activeBooks = _bookRepository.GetAllActiveBooks()
                .ProjectTo<BookForListVm>(_mapper.ConfigurationProvider);

            return activeBooks;
        }

        public IQueryable<BookFullNameVm> GetAllActiveBooksFullName()
        {
            var books = GetAllActiveBooks();
            var booksVm = books.ProjectTo<BookFullNameVm>(_mapper.ConfigurationProvider);
            return booksVm;
        }

        public IQueryable<CategoryVm> GetCategoriesToSelectList()
        {
            var categoriesVm = _categoryRepository.GetAllCategories().ProjectTo<CategoryVm>(_mapper.ConfigurationProvider);
            return categoriesVm;
        }

        public IQueryable<PublisherVm> GetPublishersToSelectList()
        {
            var publishersVm = _publisherRepository.GetAllPublishers().ProjectTo<PublisherVm>(_mapper.ConfigurationProvider);
            return publishersVm;
        }

        public IQueryable<TypeOfBookVm> GetTypeOfBooksToSelectList()
        {
            var typeOfBooksVm = _typeOfBookRepository.GetAllTypeOfBooks().ProjectTo<TypeOfBookVm>(_mapper.ConfigurationProvider);
            return typeOfBooksVm;
        }
        public IQueryable<AuthorVm> GetAuthorsToSelectList()
        {
            var authorsVm = _authorRepository.GetAllAuthors().ProjectTo<AuthorVm>(_mapper.ConfigurationProvider);
            return authorsVm;
        }
        public NewBookVm SetParametersToVm(NewBookVm model)
        {
            model.Authors = GetAuthorsToSelectList().ToList();
            model.Categories = GetCategoriesToSelectList().ToList();
            model.TypeOfBooks = GetTypeOfBooksToSelectList().ToList();
            model.Publishers = GetPublishersToSelectList().ToList();
            return model;
        }

        public void ChangeStatusOfBook(int id, Status status)
        {
            _bookRepository.ChangeStatusOfBook(id, status);
        }
       
    }
}
