using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Psotify.DataModel
{
    public class PsotifyDbContext : DbContext
    {
        public DbSet<Song> Songs { get; set; }

        public DbSet<Artist> Artists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Psotify;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Song>().HasData(
            //    new Song
            //    {
            //        SongId = 1,
            //        Title = "Imagine",
            //        Artist = "John lennon",
            //        Length = "3:04"
            //    },

            //    new Song
            //    {
            //        SongId = 2,
            //        Title = "Wish You Were Here",
            //        Artist = "Pink Floyd",
            //        Length = "5:40"
            //    }
            //);
        }


    }

    public class Song
    {
        public int SongId { get; set; }

        [Required]
        [MaxLength(100)]

        public string Title { get; set; }

        [MaxLength(10)]

        public string Length { get; set; }

        public int ArtistId { get; set; }

        public Artist Artist { get; set; }

        
    }

    public class Artist
    {
        public int ArtistId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public List<Song> Songs { get; set; }
    }

}