using Microsoft.EntityFrameworkCore;
using NetCore.Domain.Models.User;

namespace NetCore.Infrastructure.Data;

public class DatabaseContext : DbContext
{
    public DbSet<User> Users {get; set;}
    private readonly IConfiguration configuration;
    private readonly IWebHostEnvironment enviroment;

    public DatabaseContext(DbContextOptions<DatabaseContext> options, IConfiguration configuration, IWebHostEnvironment enviroment) : base(options)
    {
        this.configuration = configuration;
        this.enviroment = enviroment;

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(!optionsBuilder.IsConfigured)
        {
            string? connectionString = this.configuration.GetConnectionString(this.enviroment.EnvironmentName);

            if(connectionString is null)
            {
                throw new ArgumentNullException(nameof(connectionString));
            }

            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

            //Possibly add a switch here for multi-db types
        }

        base.OnConfiguring(optionsBuilder);
    }
}