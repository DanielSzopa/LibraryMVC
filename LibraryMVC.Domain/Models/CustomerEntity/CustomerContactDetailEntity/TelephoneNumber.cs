
namespace LibraryMVC.Domain.Models
{
    public class TelephoneNumber
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int CustomerContactDetailId { get; set; }
        public CustomerContactDetail CustomerContactDetail { get; set; }

    }
}