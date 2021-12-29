using System.Linq;

namespace LibraryMVC.Application
{
    public interface ICustomerService
    {
        int AddCustomer(NewCustomerVm newCustomerVm);
        void AddCustomerAfterConfirmEmail(string userId, string mail);        
        int UpdateCustomer(NewCustomerVm customerVm);
        bool IsCustomerDetailsAreCorrect(string userId);
        int GetCustomerIdByUserId(string userId);
        NewCustomerVm GetCustomerForEdit(int id);
        CustomerForReservationOrRentalVm GetCustomerForReservationByUserId(string userId);
        CustomerForReservationOrRentalVm GetCustomerForRentalByCustomerId(int customerId);
        CustomerDetailsVm GetCustomerDetailsByCustomerId(int customerId);
        CustomerDetailsVm GetCustomerDetailsByUserId(string userId);
        CustomerListVm GetAllCustomerToList(int pageNumber, int pageSize, string searchString);
        IQueryable<CustomerFullNameVm> GetAllCustomersFullName();

    }
}
