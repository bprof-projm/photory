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
        private readonly string ConnectionStrinPassword;

        public PhotoryDbContext(string ConnectionStrinPassword)
        {
            this.ConnectionStrinPassword = ConnectionStrinPassword;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new SqlConnectionStringBuilder("Server=tcp:photory.database.windows.net,1433;Initial Catalog=DataPhotory;Persist Security Info=False;User ID=akosgdcsi;Password={ConnectionStrinPassword};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
                optionsBuilder
            }
        }


        public virtual DbSet<PhotoryModels.User> Users { get; set; }
        public virtual DbSet<PhotoryModels.Group> Groups { get; set; }
        public virtual DbSet<PhotoryModels.Photo> Photos { get; set; }
        public virtual DbSet<PhotoryModels.Comment> Comments { get; set; }
    }
}
