using System;
using System.Collections.Generic;
using Audit.Core;
using Audit.EntityFramework;
using Audit.EntityFramework.ConfigurationApi;
using Microsoft.EntityFrameworkCore;

namespace Audit.NET.Issues.DemoFor140.Audit
{
    public class AuditContext : IAuditDbContext
    {
        public DbContext DbContext { get; set; }
        public string AuditEventType { get; set; }
        public bool AuditDisabled { get; set; }
        public bool IncludeEntityObjects { get; set; }
        public AuditOptionMode Mode { get; set; }
        public Dictionary<string, object> ExtraFields { get; set; }
        public Dictionary<Type, EfEntitySettings> EntitySettings { get; set; }
        public AuditDataProvider AuditDataProvider { get; set; }
        public void OnScopeCreated(AuditScope auditScope) { }
        public void OnScopeSaving(AuditScope auditScope) { }
    }
}
