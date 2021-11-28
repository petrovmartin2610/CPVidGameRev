using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CPVidGameRev.Models
{
    public class VidGameRevDBContext : DbContext
    {
        public VidGameRevDBContext() : base("ConnectionString")
        {
            Database.SetInitializer<VidGameRevDBContext>(new CreateDatabaseIfNotExists<VidGameRevDBContext>());
        }
        public DbSet<GameGenre> GameGenres { get; set; }
        public DbSet<GameReview> GameReviews { get; set; }
        public DbSet<UserReview> UserReviews { get; set; }
    }
}