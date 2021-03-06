using LibraryMVC.Domain;
using System.Linq;

namespace LibraryMVC.Application
{
    public interface IBookService 
    {
        int AddBook(NewBookVm model);
        void DeleteBook(int id);
        void UpdateBook(NewBookVm model);
        bool IsBookHaveThisStatus(int bookId, Status status);
        NewBookVm GetBookForEdit(int id);
        BookDetailsVm GetBookDetails(int bookId);
        BookDetailsForReservationOrRentalVm GetBookDetailsForReservationOrRental(int id);
        BookListVm GetAllBooksToList(int pageNumber, int pageSize, string searchString, string filter, int filterId);
        IQueryable<BookForListVm> GetAllActiveBooks();
        IQueryable<BookFullNameVm> GetAllActiveBooksFullName();
        IQueryable<CategoryVm> GetCategoriesToSelectList();
        IQueryable<PublisherVm> GetPublishersToSelectList();
        IQueryable<TypeOfBookVm> GetTypeOfBooksToSelectList();
        IQueryable<AuthorVm> GetAuthorsToSelectList();
        NewBookVm SetParametersToVm(NewBookVm model);     
        void ChangeStatusOfBook(int id, Status status);

    }
}
