using HaircutSite.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace HaircutSite.Infrastructure.Context
{
    public class ApplicationContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public ApplicationContext(IConfiguration configuration, DbContextOptions options) : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<HaircutStyles> HairCutStyles { get; set; } = null!;
        public DbSet<SignUps> SignUps { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite
                (_configuration.GetConnectionString("DefaultConnection"))
                .UseLoggerFactory(CreateLoggerFactory())
                .EnableSensitiveDataLogging();
        }

        public ILoggerFactory CreateLoggerFactory() =>
            LoggerFactory.Create(builder => { builder.AddConsole(); });
    }
}
