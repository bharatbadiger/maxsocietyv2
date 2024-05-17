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
    }
}