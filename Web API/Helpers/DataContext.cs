using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MoventureApi.Entities;

namespace MoventureApi.Helpers
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Movie> MoviesList { get; set; }

        public DbSet<MovieDetail> MovieDetail { get; set; }

        public DbSet<Cast> CastList { get; set; }

        public DbSet<MarkAsSeen> MarkAsSeen { get; set; }
        public DbSet<Thumbnail> Thumbnails { get; set; }

        public DbSet<MovieCast> MovieCastMaping { get; set; }

        private readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // in memory database used for simplicity, change to a real db for production applications
            options.UseInMemoryDatabase("TestDb");
        }
    }
}