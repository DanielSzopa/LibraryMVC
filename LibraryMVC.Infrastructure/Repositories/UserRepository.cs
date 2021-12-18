using LibraryMVC.Domain;
using Microsoft.AspNetCore.Identity;
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

        public void UpdateRole(string userId, string roleId)
        {           
            var user = _context.Users
                .FirstOrDefault(u => u.Id == userId);

            if (!(user is null))
            {
                var oldUserRole = _context.UserRoles
               .Where(u => u.UserId == userId)
               .Select(u => new IdentityUserRole<string>
               {
                    UserId = u.UserId,
                    RoleId = u.RoleId 
               }).Single();
                
                var newUserRole = new IdentityUserRole<string>()
                {
                    RoleId = roleId,
                    UserId = userId
                };

                _context.UserRoles.Remove(oldUserRole);
                _context.UserRoles.Add(newUserRole);
                _context.SaveChanges();
            }
            
        }
    }
}
