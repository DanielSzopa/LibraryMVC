using System.Linq;

namespace LibraryMVC.Domain
{
    public interface ICustomerRepository
    {
        int AddCustomer(Customer customer);
        int GetCustomerIdByUserId(string userId);
        Customer GetCustomerByUserId(string id);
        Customer GetCustomerByCustomerId(int id);
        int UpdateCustomer(Customer customer);
        IQueryable<Customer> GetAllCustomers();
    }
}
