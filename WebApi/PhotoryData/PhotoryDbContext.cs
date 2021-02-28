using Microsoft.EntityFrameworkCore;
using System;
using System.Data.SqlClient;
using PhotoryModels;

namespace PhotoryData
{
    public class PhotoryDbContext:DbContext
    {

        public PhotoryDbContext()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new SqlConnectionStringBuilder("Server=tcp:photory.database.windows.net,1433;Initial Catalog=DataPhotory;Persist Security Info=False;User ID=akosgdcsi;Password=Akos1999;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;");
               
                optionsBuilder.UseSqlServer();
            }
        }


        public virtual DbSet<PhotoryModels.User> Users { get; set; }
        public virtual DbSet<> OneVote { get; set; }
        public virtual DbSet<Models.AllVotes> AllVotes { get; set; }
    }
}
