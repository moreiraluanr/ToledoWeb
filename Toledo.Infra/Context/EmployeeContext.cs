using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Toledo.Domain.Entities;

namespace Toledo.Infra.Context
{
    public class EmployeeContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public EmployeeContext(DbContextOptions<EmployeeContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<Employee> Employees { get; set; }

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
