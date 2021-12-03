using LibraryMVC.Domain;

namespace LibraryMVC.Application
{
    public interface IAuthorService
    {
        int AddAuthor(NewAuthorVm model);
        void DeleteAuthor(int id);
        int EditAuthor(AuthorDetailsVm model);
        void ChangeAuthorBeforeDelete(int id);
        NewAuthorVm GetAuthorForEdit(int id);
        string GetAuthorFullName(int id);      
        AuthorListVm GetAllAuthorToList(int pageNumber, int pageSize, string searchString);
        AuthorDetailsVm SetAuthorDetails(Author author);
        AuthorDetailsVm GetAuthorDetailsByAuthorId(int id);
        AuthorDetailsVm GetAuthorDetailsByBookId(int id);

    }
}
