using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using TestEfCoreUpdate.Models;

namespace TestEfCoreUpdate.Migrations
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            var connectionString = Environment.GetEnvironmentVariable("SqlServerDb");
            if (connectionString is null) throw new Exception("Could not get connection string environment variable");

            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            optionsBuilder.UseSqlServer(connectionString,
                options => options.MigrationsAssembly("TestEfCoreUpdate.Migrations").EnableRetryOnFailure());
            return new MyContext(optionsBuilder.Options);
        }
    }
}
