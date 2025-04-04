using GISDevelopment.Models;
using Microsoft.EntityFrameworkCore;

namespace GISDevelopment.Data;

public class DatabaseContext : DbContext
{
    private readonly IConfiguration _configuration;
    
    public DbSet<Municipality> Municipalities { get; set; }
    
    public DatabaseContext(DbContextOptions<DatabaseContext> options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"),
            o => o.UseNetTopologySuite());
    }
}