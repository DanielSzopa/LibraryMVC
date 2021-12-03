using LibraryMVC.Domain;

namespace LibraryMVC.Infrastructure
{
    public class RentalRepository : IRentalRepository
    {
        private readonly Context _context;
        public RentalRepository(Context context)
        {
            _context = context;
        }
    }
}
