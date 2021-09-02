using AutoMapper;
using AutoMapper.QueryableExtensions;
using LibraryMVC.Domain.Interfaces;
using LibraryMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace LibraryMVC.Application
{
    public class BookService : IBookService
    {
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IPaginationService _paginationService;
        public BookService(IBookRepository bookRepository, IAuthorRepository authorRepository, IMapper mapper, IPaginationService paginationService)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _paginationService = paginationService;
            _authorRepository = authorRepository;
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
        public void AddCategory(CategoryVm model)
        {
            var category = _mapper.Map<Category>(model);
            _bookRepository.AddCategory(category);
        }      
        public NewBookVm GetBookForEdit(int id)
        {
            var book = _bookRepository.GetBookById(id);
            var bookVm = _mapper.Map<NewBookVm>(book); //błąd mapowania
            var model = SetParametersToVm(bookVm);
            return model;
        }

        public Book GetBookById(int id)
        {
            var book = _bookRepository.GetBookById(id);
            return book;
        }

        public BookDetailsVm GetBookDetails(int bookId)
        {
            var book = _bookRepository.GetBookById(bookId);
            var bookDetailVm = _mapper.Map<BookDetailsVm>(book);

            return bookDetailVm;
        }
        public BookListVm GetAllBooksToList(int pageNumber, int pageSize)
        {
            var books = _bookRepository.GetAllBooks()
                .ProjectTo<BookForListVm>(_mapper.ConfigurationProvider).ToList();

            var records = _paginationService.ReturnRecordsToShow<BookForListVm>(pageNumber, pageSize, books);   

            var result = new BookListVm()
            {
                ListOfBookForList = records,
                Count = books.Count,
                PageSize = pageSize,
                PageNumber = pageNumber,

            };
            return result;
        }

        public IQueryable<CategoryVm> GetBookCategories()
        {
            var categoriesVm = _bookRepository.GetAllCategories().ProjectTo<CategoryVm>(_mapper.ConfigurationProvider);
            return categoriesVm;
        }

        public IQueryable<PublisherVm> GetBookPublishers()
        {
            var publishersVm = _bookRepository.GetAllPublishers().ProjectTo<PublisherVm>(_mapper.ConfigurationProvider);
            return publishersVm;
        }

        public IQueryable<TypeOfBookVm> GetBookTypeOfBooks()
        {
            var typeOfBooksVm = _bookRepository.GetAllTypeOfBooks().ProjectTo<TypeOfBookVm>(_mapper.ConfigurationProvider);
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
            model.Categories = GetBookCategories().ToList();
            model.TypeOfBooks = GetBookTypeOfBooks().ToList();
            model.Publishers = GetBookPublishers().ToList();

            return model;
        }       
     
        public CategoryListVm GetAllCategoriesToList()
        {          
            var categories = GetBookCategories()               
                .ToList();

            var result = new CategoryListVm
            {
                CategoriesOfBooks = categories              
            };

            return result;
        }

        public TypeOfBookListVm GetAllTypeOfBooksToList()
        {
            var typeOfBooks = GetBookTypeOfBooks()
               .ToList();

            var result = new TypeOfBookListVm
            {
                TypesOfBooks = typeOfBooks
            };

            return result;
        }

        public PublisherListVm GetAllPublishersToList()
        {
            var publishers = GetBookPublishers()
                .ToList();

            var result = new PublisherListVm
            {
                Publishers = publishers
            };

            return result;
        }
       
    }
}
