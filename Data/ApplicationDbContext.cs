using Maxsociety.Models;
using Microsoft.EntityFrameworkCore;

namespace Maxsociety.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Visitors> Visitors { get; set; }
        public DbSet<VisitorLogs> VisitorLogs { get; set; }


        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var currentTime = DateTime.UtcNow;
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is BaseEntity baseEntity)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            baseEntity.CreatedOn = currentTime;
                            baseEntity.UpdatedOn = currentTime;
                            break;
                        case EntityState.Modified:
                            baseEntity.UpdatedOn = currentTime;
                            break;
                    }
                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}