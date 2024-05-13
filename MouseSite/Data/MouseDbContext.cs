using Microsoft.EntityFrameworkCore;
using MouseSite.Models;

namespace MouseSite.Data
{
    public class MouseDbContext : DbContext
    {
        public MouseDbContext(DbContextOptions<MouseDbContext> options) :base (options) // Connection dtring lai DbCOntext ma pass hanya basically.
        {}

        public DbSet<Categ> Categs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Categ>().HasData(
                new Categ { CategoryId = 1, Name = "SciFi", DisplayOrder = 1 },
                new Categ { CategoryId = 2, Name = "Action", DisplayOrder = 2 },
                new Categ { CategoryId = 3, Name = "Fiction", DisplayOrder = 3 },
                new Categ { CategoryId = 4, Name = "Fantasy", DisplayOrder = 24 }
                );
           }
       }
        
    

    }    

