using Maxsociety.Data;
using Maxsociety.Models;
using Microsoft.EntityFrameworkCore;

namespace Maxsociety.Services
{
    public class VisitorLogsService : IVisitorLogsService
    {
        private readonly ApplicationDbContext _context;

        public VisitorLogsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<VisitorLogs>> GetVisitorLogsAsync()
        {
            return await _context.VisitorLogs.Include(vl => vl.Visitor).ToListAsync();
        }

        public async Task<VisitorLogs> GetVisitorLogByIdAsync(long id)
        {
            return await _context.VisitorLogs.Include(vl => vl.Visitor)
            .FirstOrDefaultAsync(vl => vl.VisitorLogId == id);
        }

        public async Task<VisitorLogs> AddVisitorLogAsync(VisitorLogs visitorLog)
        {
            _context.VisitorLogs.Add(visitorLog);
            await _context.SaveChangesAsync();
            return visitorLog;
        }

        public async Task UpdateVisitorLogAsync(long id, VisitorLogs visitorLog)
        {
            _context.Entry(visitorLog).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteVisitorLogAsync(long id)
        {
            var visitorLog = await _context.VisitorLogs.FindAsync(id);
            if (visitorLog == null)
            {
                throw new KeyNotFoundException("VisitorLog not found");
            }

            _context.VisitorLogs.Remove(visitorLog);
            await _context.SaveChangesAsync();
        }
    }
}
