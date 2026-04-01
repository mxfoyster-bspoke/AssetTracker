using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AssetTracker.Data;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        
        // Use your actual connection string here
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=AssetTrackerDb;Trusted_Connection=True;");

        return new AppDbContext(optionsBuilder.Options);
    }
}