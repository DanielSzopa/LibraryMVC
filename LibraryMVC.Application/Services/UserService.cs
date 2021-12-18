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
        private readonly IPaginationService _paginationService;
        private readonly ICustomerRepository _customerRepository;

        public UserService(IHttpContextAccessor httpContextAccessor, UserManager<IdentityUser> userManager,
            IUserRepository userRepository, IPaginationService paginationService,
            ICustomerRepository customerRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _userRepository = userRepository;
            _paginationService = paginationService;
            _customerRepository = customerRepository;
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

        public ListOfUserForVm GetAllForListOfUserForVm(int pageNumber, int pageSize, string searchString, string roleId)
        {
            var usersId = _userRepository.GetAllUserIdByRole(roleId).ToList();
            var listForUserVm = new List<UserForListVm>();
            
            foreach(var id in usersId)
            {
                var customer = _customerRepository.GetCustomerByUserId(id);
                var userVm = new UserForListVm
                {
                    Id = customer.Id,
                    FullName = customer.FirstName + " " + customer.LastName,
                    Mail = customer.CustomerContactDetail.Mail,
                    Pesel = customer.Pesel,
                    Role = roleId,
                    UserId = customer.UserId
                };
                listForUserVm.Add(userVm);
            }    
            
            var users = listForUserVm
                .Where(u => u.FullName.Contains(searchString))        
            .ToList();

            var records = _paginationService.ReturnRecordsToShow<UserForListVm>(pageNumber, pageSize, users);

            var result = new ListOfUserForVm
            {
                ListForUserVm = records,
                Roles = _userRepository.GetAllRolesId().ToList(),
                RoleId = roleId,
                PageNumber = pageNumber,
                PageSize = pageSize,
                SearchString = searchString,
                Count = users.Count
            };
            return result;
        }

        public void UpdateRole(string userId, string roleId)
        {
            _userRepository.UpdateRole(userId, roleId);
        }
    }
}
