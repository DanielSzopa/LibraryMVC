using AutoMapper;
using AutoMapper.QueryableExtensions;
using LibraryMVC.Domain;
using System.Linq;

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
            ChangeAuthorBeforeDelete(id);
            _authorRepository.DeleteAuthor(id);
        }

        public int EditAuthor(AuthorDetailsVm model)
        {
            var authorToEdit = _mapper.Map<Author>(model);
            return _authorRepository.EditAuthor(authorToEdit);
        }

        public void ChangeAuthorBeforeDelete(int id)
        {
            _authorRepository.ChangeAuthorNameToNone(id);
        }

        public NewAuthorVm GetAuthorForEdit(int id)
        {
            var author = _authorRepository.GetAuthorById(id);
            var authorVm = _mapper.Map<NewAuthorVm>(author);
            return authorVm;
        }
        public string GetAuthorFullName(int id)
        {
            var author = _authorRepository.GetAuthorById(id);
            var fullName = author.FirstName + " " + author.LastName;
            return fullName;
        }
    
        public AuthorListVm GetAllAuthorToList(int pageNumber, int pageSize, string searchString)
        {
            var authors = _authorRepository.GetAllAuthors()
                .Where(a => (a.FirstName + " " + a.LastName)
                .Contains(searchString))
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
                PageSize = pageSize,
                SearchString = searchString

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
        
        public AuthorDetailsVm GetAuthorDetailsByAuthorId(int id)
        {
            var author = _authorRepository.GetAuthorById(id);
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
    }
}
