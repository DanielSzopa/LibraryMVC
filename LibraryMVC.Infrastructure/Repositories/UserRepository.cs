using LibraryMVC.Domain;

namespace LibraryMVC.Infrastructure
{
    public class UserRepository : IUserRepository
    {
        private readonly Context _context;
        public UserRepository(Context context)
        {
            _context = context;
        }


    }
}
