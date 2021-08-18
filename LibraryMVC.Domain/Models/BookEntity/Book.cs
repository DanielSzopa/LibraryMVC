using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryMVC.Domain.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [Column(TypeName = "date")]
        public DateTime DateOfRelease { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
        public int PublisherId { get; set; }    
        public int CategoryId { get; set; } 
        public int TypeOfBookId { get; set; }
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
        public virtual Publisher Publisher { get; set; }
        public virtual Category Category { get; set; }
        public virtual TypeOfBook TypeOfBook { get; set; }
        public virtual List<Reservation> Reservations { get; set; }
   
    }
    public enum Status
    {
        Reservation,
        Rental,
        Active,
    }
}
