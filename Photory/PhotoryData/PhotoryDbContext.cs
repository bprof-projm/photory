using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using PhotoryModels;
using System.Linq;

namespace PhotoryData
{
    public class PhotoryDbContext:DbContext
    {
        public PhotoryDbContext()
        {
            this.Database.EnsureCreated();
        }

        public PhotoryDbContext(DbContextOptions<PhotoryDbContext> db) : base(db)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies().
                    UseSqlServer(@"Server=tcp:photorydata.database.windows.net,1433;Initial Catalog=PhotoryDatabase;Persist Security Info=False;User ID=HegedusMate;Password=Passw0rd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            //modelBuilder.Entity<UserGroup>()
            //    .HasKey(ug => new { ug.UserName, ug.GroupName });
            //modelBuilder.Entity<UserGroup>()
            //    .HasOne(ug => ug.User)
            //    .WithMany(u => u.UserGroups)
            //    .HasForeignKey(ug => ug.UserName);
            //modelBuilder.Entity<UserGroup>()
            //    .HasOne(ug => ug.Group)
            //    .WithMany(g => g.UserGroups)
            //    .HasForeignKey(ug => ug.GroupName);


            modelBuilder.Entity<Comment>(entity =>
            {

                entity
                .HasOne(comment => comment.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserID);

            });


            //modelBuilder.Entity<Photo>(entity =>
            //{
            //    entity
            //    .HasOne(p => p.Group)
            //    .WithMany(g => g.Photos)
            //    .HasForeignKey(p => p.GroupId);
            //});

            //modelBuilder.Entity<Comment>(entity =>
            //{
            //    entity
            //    .HasOne(c => c.Photo)
            //    .WithMany(p => p.Comments)
            //    .HasForeignKey(c => c.PhotoID);


            //});


            modelBuilder.Entity<CommentOfPhoto>(entity =>
            {
                entity
                .HasOne(c => c.Photo)
                .WithMany(p => p.Comments)
                .HasForeignKey(p => p.PhotoID);

            });



            modelBuilder.Entity<PhotoOfGroup>(entity =>
            {
                entity
                .HasOne(p => p.Group)
                .WithMany(g => g.Photos)
                .HasForeignKey(p => p.GroupName);


            });


            modelBuilder.Entity<UserOfGroup>(entity =>
            {
                entity
                .HasOne(u => u.Group)
                .WithMany(g => g.UserGroups)
                .HasForeignKey(u => u.GroupName);

            });

            /*modelBuilder.Entity<User>(entity =>
            {
                entity.HasMany(user => user.Groups)
                .WithMany(groups => groups.Users)
         




            });*/



        }



        public DbSet<PhotoryModels.User> Users { get; set; }
        public virtual DbSet<PhotoryModels.Group> Groups { get; set; }
        public virtual DbSet<PhotoryModels.Photo> Photos { get; set; }
        public virtual DbSet<PhotoryModels.Comment> Comments { get; set; }
        public virtual DbSet<PhotoryModels.CommentOfPhoto> CommentOfPhoto { get; set; }
        public virtual DbSet<PhotoryModels.PhotoOfGroup> PhotoOfGroup { get; set; }
        public virtual DbSet<PhotoryModels.UserOfGroup> UserOfGroup { get; set; }
    }
}
