using System.Collections.Generic;

namespace LibraryMVC.Domain.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Biography { get; set; }
        public virtual List<Book> Books { get; set; }
    }
}
