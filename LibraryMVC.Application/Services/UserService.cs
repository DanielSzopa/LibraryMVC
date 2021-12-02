using LibraryMVC.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LibraryMVC.Application
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<IdentityUser> _userManager;
        public UserService(IHttpContextAccessor httpContextAccessor, UserManager<IdentityUser> userManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
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
    }
}
