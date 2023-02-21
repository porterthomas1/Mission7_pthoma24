using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Mission6_pthoma24.Models
{
    public class MovieContext : DbContext
    {
        // Constructor
        public MovieContext (DbContextOptions<MovieContext> options) : base (options)
        {
            // Leave blank for now
        }

        public DbSet<MovieEntry> Entries { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = 1,
                    CategoryName = "Fantasy/Adventure"
                },
               new Category
               {
                   CategoryId = 2,
                   CategoryName = "Action"
               },
               new Category
               {
                   CategoryId = 3,
                   CategoryName = "Sci-Fi"
               });

            mb.Entity<MovieEntry>().HasData(

                new MovieEntry
                {
                    MovieId = 1,
                    CategoryId = 1,
                    Title = "The Lord of the Rings: The Fellowship of the Ring",
                    Year = 2001,
                    Director = "Peter Jackson",
                    Rating = "PG-13",
                    Edited = false,
                    Lent_to = "",
                    Notes = "10/10"
                },
                new MovieEntry
                {
                    MovieId = 2,
                    CategoryId = 1,
                    Title = "The Lord of the Rings: The Two Towers",
                    Year = 2002,
                    Director = "Peter Jackson",
                    Rating = "PG-13",
                    Edited = false,
                    Lent_to = "",
                    Notes = "10/10"
                },
                new MovieEntry
                {
                    MovieId = 3,
                    CategoryId = 1,
                    Title = "The Lord of the Rings: The Return of the King",
                    Year = 2003,
                    Director = "Peter Jackson",
                    Rating = "PG-13",
                    Edited = false,
                    Lent_to = "",
                    Notes = "10/10"
                }
            );
        }
    }
}
