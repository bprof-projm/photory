using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using PhotoryModels;
using System.Linq;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace PhotoryData
{
    public class PhotoryDbContext :  IdentityDbContext<IdentityUser>
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
                    UseSqlServer(@"Server=tcp:photorydatabase.database.windows.net,1433;Initial Catalog=PhotoryDataBase;Persist Security Info=False;User ID=PhotoryAdmin;Password=Passw0rd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;", b => b.MigrationsAssembly("Photory"));
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            User newUser = new User();


            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<IdentityRole>().HasData(
                new { Id = "341743f0-asd2–42de-afbf-59kmkkmk72cf6", Name = "Admin", NormalizedName = "ADMIN" },
                new { Id = "341743f0-dee2–42de-bbbb-59kmkkmk72cf6", Name = "Customer", NormalizedName = "CUSTOMER" },
                new { Id = "555555f0-dee2–42de-bbbb-59kmkkmk72cf6", Name = "GroupAdmin", NormalizedName = "GroupAdmin" }
            );

            

            var appUser = new IdentityUser
            {
                Id = "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                Email = "hegedus.mate@nik.uni-obuda.hu",
                NormalizedEmail = "hegedus.mate@nik.uni-obuda.hu",
                EmailConfirmed = true,
                UserName = "HegedusMate",
                NormalizedUserName = "HEGEDUSMATE",
                SecurityStamp = string.Empty
            };

            var appUser2 = new IdentityUser
            {
                Id = "e2174cf0–9412–4cfe-afbf-59f706d72cf6",
                Email = "gadacsi.akos@nik.uni-obuda.hu",
                NormalizedEmail = "gadacsi.akos@nik.uni-obuda.hu",
                EmailConfirmed = true,
                UserName = "GadacsiAkos",
                NormalizedUserName = "GADACSIAKOS",
                SecurityStamp = string.Empty
            };

            var appUser3 = new IdentityUser
            {
                Id = "e3894cf0–9412–4cfe-afbf-59f706d72cf6",
                Email = "veres.levente@nik.uni-obuda.hu",
                NormalizedEmail = "veres.levente@nik.uni-obuda.hu",
                EmailConfirmed = true,
                UserName = "VeresLevente",
                NormalizedUserName = "VERESLEVENTE",
                SecurityStamp = string.Empty
            };




            appUser.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "Almafa123!");
            appUser2.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "Almafa123!");
            appUser3.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "Almafa123!");


            modelBuilder.Entity<IdentityUser>().HasData(appUser);
            modelBuilder.Entity<IdentityUser>().HasData(appUser2);
            modelBuilder.Entity<IdentityUser>().HasData(appUser3);



            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                UserId = "02174cf0–9412–4cfe-afbf-59f706d72cf6"
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "341743f0-dee2–42de-bbbb-59kmkkmk72cf6",
                UserId = "e2174cf0–9412–4cfe-afbf-59f706d72cf6"
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "555555f0-dee2–42de-bbbb-59kmkkmk72cf6",
                UserId = "e3894cf0–9412–4cfe-afbf-59f706d72cf6"
            });


            modelBuilder.Entity<User>().HasData(new User
            {
                UserName = appUser.UserName,
                FullName = appUser.UserName,
                Email = appUser.Email,
                UserAccess = UserAccess.Admin,
                BirthDate = new DateTime(2000, 12, 09),
                UserId = appUser.Id




            });

            modelBuilder.Entity<User>().HasData(new User
            {
                UserName = appUser2.UserName,
                FullName = appUser2.UserName,
                Email = appUser2.Email,
                UserAccess = UserAccess.RegularUser,
                BirthDate = new DateTime(2000, 12, 09),
                UserId = appUser2.Id




            });

            modelBuilder.Entity<User>().HasData(new User
            {
                UserName = appUser3.UserName,
                FullName = appUser3.UserName,
                Email = appUser3.Email,
                UserAccess = UserAccess.GroupAdmin,
                BirthDate = new DateTime(2000, 12, 09),
                UserId = appUser3.Id




            });



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
                .HasForeignKey(c => c.UserId);

            });


            modelBuilder.Entity<Photo>(entity =>
            {
                entity
                .HasOne(p => p.Group)
                .WithMany(g => g.Photos)
                .HasForeignKey(p => p.GroupId);
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity
                .HasOne(c => c.Photo)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.PhotoID);


            });


            modelBuilder.Entity<UserOfGroup>(entity =>
            {
                entity
                .HasOne(u => u.Group)
                .WithMany(g => g.UserGroups)
                .HasForeignKey(u => u.GroupName)
                .OnDelete(DeleteBehavior.Cascade);

            });

            /*modelBuilder.Entity<User>(entity =>
            {
                entity.HasMany(user => user.Groups)
                .WithMany(groups => groups.Users)
         




            });*/



        }



        public DbSet<PhotoryModels.User> MyUsers { get; set; }
        public virtual DbSet<PhotoryModels.Group> Groups { get; set; }
        public virtual DbSet<PhotoryModels.Photo> Photos { get; set; }
        public virtual DbSet<PhotoryModels.Comment> Comments { get; set; }
        public virtual DbSet<PhotoryModels.UserOfGroup> UserOfGroup { get; set; }
    }
}
