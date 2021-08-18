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
        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
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
            int excludeRecords = (pageSize * pageNumber) - pageSize;
            var books = _bookRepository.GetAllBooks()
                .ProjectTo<BookForListVm>(_mapper.ConfigurationProvider).ToList();

            var booksToShow = books
                .Skip(excludeRecords)
                .Take(pageSize)
                .ToList();

            var result = new BookListVm()
            {
                ListOfBookForList = booksToShow,
                Count = books.Count,
                PageSize = pageSize,
                CurrentPage = pageNumber,

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
            var publisherVm = _bookRepository.GetAllPublishers().ProjectTo<PublisherVm>(_mapper.ConfigurationProvider);
            return publisherVm;
        }

        public IQueryable<TypeOfBookVm> GetBookTypeOfBooks()
        {
            var typeOfBooksVm = _bookRepository.GetAllTypeOfBooks().ProjectTo<TypeOfBookVm>(_mapper.ConfigurationProvider);
            return typeOfBooksVm;
        }

        public NewBookVm SetParametersToVm(NewBookVm model)
        {
            model.Authors = GetAuthorsToSelectList().ToList();
            model.Categories = GetBookCategories().ToList();
            model.TypeOfBooks = GetBookTypeOfBooks().ToList();
            model.Publishers = GetBookPublishers().ToList();

            return model;
        }
        public AuthorDetailsVm GetAuthorDetailsByBookId(int id)
        {
            var author = _bookRepository.GetAuthorByBookId(id);
            var authorVm = _mapper.Map<AuthorDetailsVm>(author);
            var authorBooks = _bookRepository.GetAllBooksByAuthor(id).ToList();

            authorVm.Books = authorBooks;
            authorVm.BooksNumber = authorBooks.Count;
            authorVm.IdCurrentBook = id;
            return authorVm;
        }

        public IQueryable<Author> GetAllAuthors()
        {
            var authors = _bookRepository.GetAllAuthors();
            return authors;
        }

        public IQueryable<AuthorVm> GetAuthorsToSelectList()
        {
            var authorsVm = GetAllAuthors().ProjectTo<AuthorVm>(_mapper.ConfigurationProvider);
            return authorsVm;
        }

        public AuthorListVm GetAllAuthorToList()
        {
            var authorsForList = _bookRepository.GetAllAuthors()
                .ProjectTo<AuthorForListVm>(_mapper.ConfigurationProvider)
                .ToList();

            foreach(var authorVm in authorsForList)
            {              
                authorVm.NumberOfBooks = _bookRepository.CountAuthorsBooks(authorVm.Id);
            }
            var result = new AuthorListVm
            {
                Authors = authorsForList,
                Count = authorsForList.Count
            };

         return result;
        }

        public int AddAuthor(NewAuthorVm model)
        {
            var authorVm = _mapper.Map<Author>(model);
            return _bookRepository.AddAuthor(authorVm);
        }
    }
}
