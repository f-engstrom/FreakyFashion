using FreakyFashion.RazorPages.Models;
using Microsoft.EntityFrameworkCore;

namespace FreakyFashion.Data
{
    public class FreakyFashionContext:DbContext
    {


        public FreakyFashionContext(DbContextOptions<FreakyFashionContext> options)
            : base(options)
        {
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ClothesSizes>()
                .HasKey(sc => new { sc.ClothingId, sc.SizeId });

            modelBuilder.Entity<ClothesSizes>()
                .HasOne(a => a.Clothing)
                .WithMany(m => m.Sizes)
                .HasForeignKey(a => a.ClothingId);

            modelBuilder.Entity<ClothesSizes>()
                .HasOne(m => m.Size)
                .WithMany(a => a.Clothes)
                .HasForeignKey(m => m.SizeId);

        }



        public DbSet<Clothing> Clothing { get; set; }



        public DbSet<Category> Category { get; set; }
    }
}
