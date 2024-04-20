using System;
using EcommerceWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceWeb.Data
{
	public class ApplicationDbContext: DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
		{
		}

		public DbSet<Category> Categories { get; set; }

        //OnModelCreating is a .Net EntityFrameworkCore providing class for inserting data in database. Add migrations and update database after creating model builder.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			modelBuilder.Entity<Category>().HasData(
				new Category { Id=1,Name="Science",DisplayOrder=1},
				new Category { Id = 2, Name = "Fiction", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Non-Fiction", DisplayOrder =3 });
            //base.OnModelCreating(modelBuilder);
        }
    }
}

