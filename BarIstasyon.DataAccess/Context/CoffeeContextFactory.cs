using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using BarIstasyon.DataAccess.Context;

public class CoffeeContextFactory : IDesignTimeDbContextFactory<CoffeeContext>
{
    public CoffeeContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<CoffeeContext>();
        optionsBuilder.UseMongoDB(
            "mongodb://localhost:27017",
            "BarIstasyon"
        );

        return new CoffeeContext(optionsBuilder.Options);
    }
}
