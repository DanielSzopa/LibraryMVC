using LibraryMVC.Domain;
using System.Linq;

namespace LibraryMVC.Infrastructure
{
    public class UserRepository : IUserRepository
    {
        private readonly Context _context;
        public UserRepository(Context context)
        {
            _context = context;
        }

        public IQueryable<string> GetAllRolesId()
        {
            var roles = _context.Roles
                .Select(r => r.Id);

            return roles;
        }

        public IQueryable<string> GetAllUserIdByRole(string roleId)
        {
            var usersId = _context.UserRoles
                .Where(r => r.RoleId == roleId)
                .Select(u => u.UserId);                        

            return usersId;
        }

        public int GetUserNumberByRoleId(string roleId)
        {
            var userNumber = _context.UserRoles
                .Where(r => r.RoleId == roleId)
                .Count();

            return userNumber;
        }
    }
}
