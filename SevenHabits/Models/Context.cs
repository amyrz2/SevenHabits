using System;
using Microsoft.EntityFrameworkCore;
namespace SevenHabits.Models
{
    public class Context : DbContext
    {
        //Constructor
        public Context (DbContextOptions<Context> options) : base(options)
        {
            //Leave blank for now
        }


        public DbSet<TaskClass> habits { get; set; }

        public DbSet<Category> Categories { get; set; }


        //Seed Data
        protected override void OnModelCreating(ModelBuilder mb)
        {
            //Seed Category ID's and Names
            mb.Entity<Category>().HasData(

                new Category { CategoryID = 1, CategoryName = "Home" },
                new Category { CategoryID = 2, CategoryName = "School" },
                new Category { CategoryID = 3, CategoryName = "Work" },
                new Category { CategoryID = 4, CategoryName = "Church" }


                );

        }



    }
}

