using System.Threading.Tasks;
using Audit.NET.Issues.DemoFor140.Entities;
using Audit.NET.Issues.DemoFor140.EntityFrameworkCore;

namespace Audit.NET.Issues.DemoFor140
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            using (var dbContext = new AppDbContextFactory().CreateDbContext(args))
            {
                dbContext.Customers.Add(new Customer
                {
                    Name = "John Doe"
                });
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
