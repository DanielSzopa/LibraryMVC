using System.Linq;

namespace LibraryMVC.Domain
{
    public interface IUserRepository
    {
        IQueryable<string> GetAllRolesId();
        int GetUserNumberByRoleId(string roleId);
        IQueryable<string> GetAllUserIdByRole(string roleId);
        void UpdateRole(string userId, string roleId);
    }
}
