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
            //Default Data
            modelBuilder.Entity<Category>()
                .HasData(new Category { Id = 1, Name = "Other" });

            modelBuilder.Entity<Publisher>()
                .HasData(new Publisher { Id = 1, Name = "Other" });

            modelBuilder.Entity<TypeOfBook>()
                .HasData(new TypeOfBook { Id = 1, Name = "Other" });

            modelBuilder.Entity<Author>()
               .HasData(new Author { Id = 1, FirstName = "none", LastName = "none", Biography = "none" });

            //Example Data

            modelBuilder.Entity<Category>()
               .HasData(
               new Category { Id = 2, Name = "Book" },
               new Category { Id = 3, Name = "Newspaper" }
               );

            modelBuilder.Entity<Publisher>()
               .HasData(
               new Publisher { Id = 2, Name = "New Era" },
               new Publisher { Id = 3, Name = "Opera" }
               );

            modelBuilder.Entity<TypeOfBook>()
               .HasData(
               new TypeOfBook { Id = 2, Name = "Crime Story" },
               new TypeOfBook { Id = 3, Name = "Romantic" }
               );

            modelBuilder.Entity<Author>()
               .HasData(
               new Author { Id = 2, FirstName = "Katarzyna", LastName = "Bonda", Biography = "Polska dziennikarka i scenarzystka, autorka bestsellerowych powieści kryminalnych" },
               new Author { Id = 3, FirstName = "Agatha", LastName = "Christie", Biography = "Brytyjska autorka powieści kryminalnych i obyczajowych" }
               );

            modelBuilder.Entity<Book>()
                .HasData(
                new Book { Id = 1, Title = "Lampiony", DateOfRelease = new DateTime(2010, 01, 01), Description = "Sasza Załuska zostaje przyjęta na cywilny etat do gdańskiej policji i natychmiast oddelegowana do zadania w Łodzi.", Status = Status.Active, PublisherId = 2, CategoryId = 2, TypeOfBookId = 2, AuthorId = 2 },
                new Book { Id = 2, Title = "Lalka", DateOfRelease = new DateTime(2000, 01, 01), Description = "Historia zamożnego kupca warszawskiego Stanisława Wokulskiego i jego miłości do pięknej, lecz zubożałej arystokratki Izabeli Łęckiej.", Status = Status.Active, PublisherId = 3, CategoryId = 2, TypeOfBookId = 2, AuthorId = 3 },
                new Book { Id = 3, Title = "Pan Tadeusz", DateOfRelease = new DateTime(1990, 01, 01), Description = "Ta epopeja narodowa (z elementami gawędy szlacheckiej) powstała w latach 1832–1834 w Paryżu.", Status = Status.Active, PublisherId = 3, CategoryId = 2, TypeOfBookId = 2, AuthorId = 3 },
                new Book { Id = 4, Title = "Biografia Daniela Szopy", DateOfRelease = new DateTime(2015, 01, 01), Description = "Czasopismo opowiadające o początku kariery Junior Developera", Status = Status.Active, PublisherId = 2, CategoryId = 3, TypeOfBookId = 2, AuthorId = 2 },
                new Book { Id = 5, Title = "Wesele", DateOfRelease = new DateTime(2016, 01, 01), Description = "„Wesele” stanowi najważniejszy młodopolski dramat. w Łodzi.", Status = Status.Active, PublisherId = 2, CategoryId = 2, TypeOfBookId = 2, AuthorId = 2 },
                new Book { Id = 6, Title = "Miłość w Zakopanem", DateOfRelease = new DateTime(2018, 01, 01), Description = "Historia dwojga ludzi, którzy zakochali się w Zakopanem", Status = Status.Active, PublisherId = 2, CategoryId = 2, TypeOfBookId = 2, AuthorId = 3 }
            );

        }    
    }
}
