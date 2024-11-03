using BulkyWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyWeb.Data
{
    public class ApplicationDbContext : DbContext   //załadowanie klasy DbContext ktora pozwala na dostęp do Entity Framework
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) //w konstruktorze przekazujemy opcje do DbContext
        {

        }
        public DbSet<Category> Categories { get; set; }         //stworzenie tabeli categories (ktora jest odzwierciedlona w aplikacji przez model Category

        protected override void OnModelCreating(ModelBuilder modelBuilder)      //dodawanie danych do bazy 
        {
            modelBuilder.Entity<Category>().HasData(                         //chcemy edytowac encje category (dodac dane do tabeli Category)
                new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Name = "SciFi", DisplayOrder = 2 },
                new Category { Id = 3, Name = "History", DisplayOrder = 3 }
                );
        }
    }
}
