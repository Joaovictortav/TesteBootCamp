using Kernel.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace Kernel.Model;

public class BootcampContext : DbContext
{
    private static AsyncLocal<BootcampContext> _instance = new ();
    internal static BootcampContext Get()
    {
        if (_instance.Value is null)
        {
            var options = new DbContextOptions<BootcampContext>();
            _instance.Value = new BootcampContext(options);
        }
        
        return _instance.Value;
    }
    public DbSet<Favorites> FavoriteSet { get; set; }
    
    internal static void ResetContext(){
        _instance.Value = null!;
    }

    public BootcampContext(DbContextOptions<BootcampContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            
            var connectionString = configuration.GetConnectionString("MySql");
            optionsBuilder.UseMySql(connectionString, ServerVersion.Parse("8.0.27-mysql"));
        }
    }
    
    public override void Dispose()
    {
        base.Dispose();
        _instance.Value = null!;
    }

}