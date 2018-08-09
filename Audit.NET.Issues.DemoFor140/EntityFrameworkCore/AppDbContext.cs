using System.Threading;
using System.Threading.Tasks;
using Audit.EntityFramework;
using Audit.NET.Issues.DemoFor140.Audit;
using Audit.NET.Issues.DemoFor140.Entities;
using Microsoft.EntityFrameworkCore;

namespace Audit.NET.Issues.DemoFor140.EntityFrameworkCore
{
    public sealed class AppDbContext : DbContext
    {
        private DbContextHelper _helper = new DbContextHelper();
        private AuditContext _auditContext = new AuditContext();
        public DbSet<Customer> Customers { get; set; }

        static AppDbContext()
        {
            EntityFramework.Configuration
                .Setup()
                .ForContext<AuditContext>(cfg => cfg.AuditEventType("EF:{database}").IncludeEntityObjects(true))
                .UseOptOut();
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public override int SaveChanges()
        {
            return _helper.SaveChanges(_auditContext, () => base.SaveChanges());
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return _helper.SaveChangesAsync(_auditContext, () => base.SaveChangesAsync(cancellationToken));
        }
    }
}