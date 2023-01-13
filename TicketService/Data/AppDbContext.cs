using TicketService.Models;
using Microsoft.EntityFrameworkCore;

namespace CardsService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt ) : base(opt)
        {
            
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Card> Cards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Movie>()
                .HasMany(p => p.Cards)
                .WithOne(p=> p.Movie!)
                .HasForeignKey(p => p.MovieId);

            modelBuilder
                .Entity<Card>()
                .HasOne(p => p.Movie)
                .WithMany(p => p.Cards)
                .HasForeignKey(p =>p.MovieId);
        }
    }
}