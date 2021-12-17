using LibraryMVC.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LibraryMVC.Application
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUserRepository _userRepository;

        public UserService(IHttpContextAccessor httpContextAccessor, UserManager<IdentityUser> userManager, IUserRepository userRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _userRepository = userRepository;
        }

       
        public async Task<string> CreateUser(string mail, string password)
        {
            var user = new IdentityUser { UserName = mail, Email = mail, EmailConfirmed = true };
            var result =  await _userManager.CreateAsync(user, password);
            return user.Id;
        }
        public async Task ChangeCustomerRoleToUser(string userId)
        {
            var user = new IdentityUser { Id = userId };
           await _userManager.AddToRoleAsync(user, "User");
        }

        public string GetCurrentUserId()
        {
            return _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public ListOfRoleForListVm GetAllRolesToList()
        {
            var roles = _userRepository.GetAllRolesId().ToList();
            var result = new List<RoleForListVm>();
            var listVm = new ListOfRoleForListVm();


            foreach (var role in roles)
            {
                var roleForList = new RoleForListVm();
                roleForList.RoleId = role;
                roleForList.CountOfUsers = _userRepository.GetUserNumberByRoleId(role);

                result.Add(roleForList);
            }

            listVm.ListOfRoles = result;

            return listVm;
        }
    }
}
