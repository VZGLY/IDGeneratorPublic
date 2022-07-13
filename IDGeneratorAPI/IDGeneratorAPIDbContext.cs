using Microsoft.EntityFrameworkCore;

namespace IDGeneratorAPI;

public class IDGeneratorAPIDbContext : DbContext
{
    public IDGeneratorAPIDbContext(DbContextOptions options) : base(options)
    {
    }

    public IDGeneratorAPIDbContext()
    {
        
    }
  
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "ConnectionString");
    }
    
    public DbSet<Country> Countries { get; set; }
    public DbSet<Name> Names { get; set; }
}