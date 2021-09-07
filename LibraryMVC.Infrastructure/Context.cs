using LibraryMVC.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryMVC.Infrastructure
{
    public class Context : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<TypeOfBook> TypeOfBooks { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<CustomerContactDetail> CustomerContactDetails { get; set; }
        public DbSet<TelephoneNumber> TelephoneNumbers { get; set; }
        public DbSet<Reservation> Reservations { get; set; } 
        public Context(DbContextOptions dbContext) : base(dbContext)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasData(new Category { Id = 1, Name = "Other" });

            modelBuilder.Entity<Publisher>()
                .HasData(new Publisher { Id = 1, Name = "Other" });

            modelBuilder.Entity<TypeOfBook>()
                .HasData(new TypeOfBook { Id = 1, Name = "Other" });

            modelBuilder.Entity<Author>()
               .HasData(new Author { Id = 1, FirstName = "none",LastName = "none", Biography = "none"});
        }    
    }
}
