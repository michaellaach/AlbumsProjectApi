using Microsoft.EntityFrameworkCore;
using MusicLibrary.DAL.Entities;

namespace MusicLibrary.DAL
{
    public class MusicLibraryContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<MusicUsers> MusicUsers { get; set; }

        public MusicLibraryContext(DbContextOptions<MusicLibraryContext> contextOptions) : base(contextOptions)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MusicUsers>()
                .HasKey(bu => new { bu.UserId, bu.AlbumId });

            modelBuilder.Entity<MusicUsers>()
                .HasOne(x => x.Album)
                .WithMany(b => b.MusicUsers)
                .HasForeignKey(bu => bu.AlbumId);

            modelBuilder.Entity<MusicUsers>()
                .HasOne(x => x.User)
                .WithMany(u => u.MusicUsers)
                .HasForeignKey(bu => bu.UserId);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }
}
