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
    public class AuthorService : IAuthorService
    {
        private readonly IMapper _mapper;
        private readonly IAuthorRepository _authorRepository;
        private readonly IPaginationService _paginationService;
        public AuthorService(IAuthorRepository authorRepository, IMapper mapper, IPaginationService paginationService)
        {
            _mapper = mapper;
            _authorRepository = authorRepository;
            _paginationService = paginationService;
        }

        public int AddAuthor(NewAuthorVm model)
        {
            var authorVm = _mapper.Map<Author>(model);
            return _authorRepository.AddAuthor(authorVm);
        }

        public void DeleteAuthor(int id)
        {
            _authorRepository.DeleteAuthor(id);
        }

        public IQueryable<Author> GetAllAuthors()
        {
            var authors = _authorRepository.GetAllAuthors();
            return authors;
        }       

        public AuthorListVm GetAllAuthorToList(int pageNumber, int pageSize)
        {
            var authors = GetAllAuthors()
                .ProjectTo<AuthorForListVm>(_mapper.ConfigurationProvider)
                .ToList();

            var records = _paginationService.ReturnRecordsToShow<AuthorForListVm>(pageNumber, pageSize, authors);

            foreach (var authorVm in records)
            {
                authorVm.NumberOfBooks = _authorRepository.CountAuthorsBooks(authorVm.Id);
            }
            var result = new AuthorListVm
            {
                Authors = records,
                Count = authors.Count,
                PageNumber = pageNumber,
                PageSize = pageSize

            };

            return result;
        }
        public AuthorDetailsVm SetAuthorDetails(Author author)
        {
            var authorVm = _mapper.Map<AuthorDetailsVm>(author);
            var authorBooks = _authorRepository.GetAllBooksByAuthor(author.Id).ToList().Count;

            authorVm.BooksNumber = authorBooks;
            return authorVm;
        }
        public NewAuthorVm GetAuthorForEdit(int id)
        {
            var author = GetAuthorById(id);
            var authorVm = _mapper.Map<NewAuthorVm>(author);
            return authorVm;
        }
        public AuthorDetailsVm GetAuthorDetailsByAuthorId(int id)
        {
            var author = GetAuthorById(id);
            var authorVm = SetAuthorDetails(author);
            return authorVm;
        }
        public AuthorDetailsVm GetAuthorDetailsByBookId(int id)
        {
            var author = _authorRepository.GetAuthorByBookId(id);
            var authorVm = SetAuthorDetails(author);

            authorVm.IdCurrentBook = id;
            return authorVm;
        }

        public int EditAuthor(AuthorDetailsVm model)
        {          
            var authorToEdit = _mapper.Map<Author>(model);

            return _authorRepository.EditAuthor(authorToEdit);
        }

        public Author GetAuthorById(int id)
        {
            return _authorRepository.GetAuthorById(id);
        }
    }
}
