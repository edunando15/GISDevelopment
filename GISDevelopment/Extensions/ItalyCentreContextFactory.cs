using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace GISDevelopment.Models;

/// <summary>
/// Class used to create the context for the Italy Centre database.
/// </summary>
public class ItalyCentreContextFactory : IDesignTimeDbContextFactory<ItalyCentreContext>
{
    public ItalyCentreContext CreateDbContext(string[] args)
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        
        var optionsBuilder = new DbContextOptionsBuilder<ItalyCentreContext>();
        var connectionString = configuration.GetConnectionString("ItalyCentreConnection");
        optionsBuilder.UseNpgsql(connectionString);
        return new ItalyCentreContext(optionsBuilder.Options, configuration);
    }
}