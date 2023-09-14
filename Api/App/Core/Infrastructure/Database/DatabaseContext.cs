using App.Core.Domain.Database;
using Microsoft.EntityFrameworkCore;
namespace App.Core.Infrastructure.Database;

public class DatabaseContext : DbContext
{
    private readonly IConfiguration configuration;
    private readonly IWebHostEnvironment enviroment;

    public DatabaseContext(
        DbContextOptions<DatabaseContext> options,
        IConfiguration configuration,
        IWebHostEnvironment enviroment
    ) : base(options)
    {
        this.configuration = configuration;
        this.enviroment = enviroment;

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            string? connectionString = this.configuration.GetConnectionString(this.enviroment.EnvironmentName);

            if (connectionString is null)
            {
                throw new ArgumentNullException(nameof(connectionString));
            }

            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

        }

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (Type entityType in DbEntityAttribute.TargetModels)
        {
            modelBuilder.Entity(entityType).ToTable(entityType.Name);
        }
        base.OnModelCreating(modelBuilder);
    }
}