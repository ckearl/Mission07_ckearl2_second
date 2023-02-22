using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission06_ckearl2.Models
{
    public class MovieContext : DbContext
    {
        // Constructor
        public MovieContext (DbContextOptions<MovieContext> options) : base(options)
        {
            // Leave blank for now
        }

        public DbSet<Movie> movies { get; set; }
        public DbSet<Category> categories { get; set; }
        
        // Seed data
        protected override void OnModelCreating(ModelBuilder mb)
        {
            
            mb.Entity<Category>().HasData(
                new Category { CategoryID = 1, CategoryName = "Comedy"},
                new Category { CategoryID = 2, CategoryName = "Action" },
                new Category { CategoryID = 3, CategoryName = "Romance" },
                new Category { CategoryID = 4, CategoryName = "Drama" },
                new Category { CategoryID = 5, CategoryName = "Documentary" },
                new Category { CategoryID = 6, CategoryName = "Animation" }

                );

            mb.Entity<Movie>().HasData(
                
                new Movie
                {
                    MovieID = 1,
                    Title = "Ferris Bueller's Day Off",
                    Year = 1986,
                    Director = "John Hughes",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "-",
                    Notes = "This movie is based in Chicago",
                    CategoryID = 1,
                },

                new Movie
                {
                    MovieID = 2,
                    Title = "School of Rock",
                    Year = 2003,
                    Director = "Mike White",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "-",
                    Notes = "Jack Black is my hero",
                    CategoryID = 1,
                },

                new Movie
                {
                    MovieID = 3,
                    Title = "The Sandlot",
                    Year = 1993,
                    Director = "David Mickey Evans",
                    Rating = "PG",
                    Edited = false,
                    LentTo = "Scotty Smalls",
                    Notes = "A cult classic",
                    CategoryID = 1,
                },

                new Movie
                {
                    MovieID = 4,
                    Title = "Whiplash",
                    Year = 2014,
                    Director = "Damian Chazelle",
                    Rating = "R",
                    Edited = true,
                    LentTo = "J.K. Simmons",
                    Notes = "GOAT movie",
                    CategoryID = 4,
                },
                
                new Movie
                {
                    MovieID = 5,
                    Title = "Good Will Hunting",
                    Year = 1997,
                    Director = "Gus Van Sant",
                    Rating = "R",
                    Edited = true,
                    LentTo = "Matt Damon",
                    Notes = "The most stacked cast of all time",
                    CategoryID = 4,
                }
            );
        }
    }
}
