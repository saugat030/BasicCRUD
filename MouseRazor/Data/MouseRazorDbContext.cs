using Microsoft.EntityFrameworkCore;
using MouseRazor.Model;

namespace MouseRazor.Data { 
       public class MouseRazorDbContext : DbContext
        {
            public MouseRazorDbContext(DbContextOptions<MouseRazorDbContext> options) : base(options) // Connection dtring lai DbCOntext ma pass hanya basically.
            { }

            public DbSet<Category> Categs { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Category>().HasData(
                    new Category { CategoryId = 1, Name = "SciFi", DisplayOrder = 1 },
                    new Category { CategoryId = 2, Name = "Action", DisplayOrder = 2 },
                    new Category { CategoryId = 3, Name = "Fiction", DisplayOrder = 3 },
                    new Category { CategoryId = 4, Name = "Fantasy", DisplayOrder = 24 }
                    );
            }
        }
    }

