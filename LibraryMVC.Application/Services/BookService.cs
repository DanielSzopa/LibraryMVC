﻿using AutoMapper;
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
        public BookListVm GetAllBooksToList(int pageNumber, int pageSize, string searchString, int categoryId, int publisherId, int typeOfBookId, int authorId)
        {
            var books = default(IQueryable<Book>);
            if(categoryId != 0)
            {
                books = _categoryRepository.GetAllBooksByCategoryId(categoryId).Where(b=>b.Title.StartsWith(searchString));
            }
            else if (publisherId != 0)
            {
                books = _publisherRepository.GetAllBooksByPublisherId(publisherId).Where(b => b.Title.StartsWith(searchString));
            }
            else if (typeOfBookId != 0)
            {
                books = _typeOfBookRepository.GetAllBooksByTypeOfBookId(typeOfBookId).Where(b => b.Title.StartsWith(searchString));
            }
            else if (authorId != 0)
            {
                books =  _authorRepository.GetAllBooksByAuthor(authorId).Where(b => b.Title.StartsWith(searchString));
            }
            else
            {
                books = _bookRepository.GetAllBooks().Where(b => b.Title.StartsWith(searchString));
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
                CategoryId = categoryId,
                PublisherId = publisherId,
                TypeOfBookId = typeOfBookId,
                AuthorId = authorId

            };
            return result;
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
     
    }
}
