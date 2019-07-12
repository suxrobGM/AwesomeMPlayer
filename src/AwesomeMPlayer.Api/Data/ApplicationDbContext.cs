using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AwesomeMPlayer.Api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AwesomeMPlayer.Api.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, UserRole, string>
    {        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Track> Tracks { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("Server=(localdb)\\ProjectsV13;Database=AwesomeMPlayerDB;Trusted_Connection=True;MultipleActiveResultSets=true")
                        .UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Changed standart identity table names
            //builder.Entity<User>(entity => { entity.ToTable(name: "Users"); });
            //builder.Entity<IdentityRole>(entity => { entity.ToTable(name: "Roles"); });
            //builder.Entity<IdentityUserRole<string>>(entity => { entity.ToTable("UserRoles"); });
            //builder.Entity<IdentityUserClaim<string>>(entity => { entity.ToTable("UserClaims"); });
            //builder.Entity<IdentityUserLogin<string>>(entity => { entity.ToTable("UserLogins"); });
            //builder.Entity<IdentityUserToken<string>>(entity => { entity.ToTable("UserToken"); });
            //builder.Entity<IdentityRoleClaim<string>>(entity => { entity.ToTable("RoleClaims"); });

            builder.Entity<User>(entity =>
            {
                entity.HasMany(m => m.OwnPlaylists)
                    .WithOne(m => m.Author)
                    .HasForeignKey(m => m.AuthorId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            builder.Entity<Track>(entity =>
            {
                entity.HasOne(m => m.Genre)
                    .WithMany(m => m.Tracks)
                    .HasForeignKey(m => m.GenreId);

                entity.HasOne(m => m.Album)
                    .WithMany(m => m.Tracks)
                    .HasForeignKey(m => m.AlbumId);
            });

            builder.Entity<TrackPlaylist>(entity =>
            {
                entity.ToTable("TrackPlaylists");
                entity.HasKey(k => new { k.PlaylistId, k.TrackId });

                entity.HasOne(m => m.Playlist)
                    .WithMany(m => m.Tracks)
                    .HasForeignKey(m => m.PlaylistId);

                entity.HasOne(m => m.Track)
                    .WithMany(m => m.TrackPlaylists)
                    .HasForeignKey(m => m.TrackId);
            });

            builder.Entity<UserAlbum>(entity =>
            {
                entity.ToTable("UserAlbums");
                entity.HasKey(k => new { k.AlbumId, k.UserId });

                entity.HasOne(m => m.Album)
                    .WithMany(m => m.SubscribedUsers)
                    .HasForeignKey(m => m.AlbumId);

                entity.HasOne(m => m.User)
                    .WithMany(m => m.SubscribedAlbums)
                    .HasForeignKey(m => m.UserId);
            });

            builder.Entity<UserPlaylist>(entity =>
            {
                entity.ToTable("UserPlaylists");
                entity.HasKey(k => new { k.PlaylistId, k.UserId });

                entity.HasOne(m => m.Playlist)
                    .WithMany(m => m.SubscribedUsers)
                    .HasForeignKey(m => m.PlaylistId);

                entity.HasOne(m => m.User)
                    .WithMany(m => m.SubscribedPlaylists)
                    .HasForeignKey(m => m.UserId);
            });
        }
    }
}
