using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Toledo.Domain.Entities;

namespace Toledo.Infra.Context
{
    public class DependentContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DependentContext(DbContextOptions<DependentContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<Dependent> Dependents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(_configuration.GetConnectionString("SqlServer"));
            }
        }
    }
}
