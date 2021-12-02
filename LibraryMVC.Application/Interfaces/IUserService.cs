using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMVC.Application
{
    public interface IUserService
    {
        string GetCurrentUserId();

        Task ChangeCustomerRoleToUser(string userId);
        Task<string> CreateUser(string mail, string password);
    }
}
