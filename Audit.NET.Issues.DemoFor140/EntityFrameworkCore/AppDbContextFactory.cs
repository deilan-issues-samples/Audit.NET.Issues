using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Audit.NET.Issues.DemoFor140.EntityFrameworkCore
{
    public sealed class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public static string DefaultConnection = "Data Source=data.db";

        public AppDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            builder.UseSqlite(DefaultConnection);
            return new AppDbContext(builder.Options);
        }
    }
}