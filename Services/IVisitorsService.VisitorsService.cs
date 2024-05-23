using AutoMapper;
using Maxsociety.Data;
using Maxsociety.DTO;
using Maxsociety.Models;
using Microsoft.EntityFrameworkCore;

namespace Maxsociety.Services 
{
    public class VisitorsService : IVisitorsService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public VisitorsService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Visitors>> GetVisitorsAsync()
        {
            return await _context.Visitors.ToListAsync();
        }

        public async Task<Visitors> GetVisitorByIdAsync(long id)
        {
            return await _context.Visitors.FindAsync(id);
        }

        public async Task<Visitors> AddVisitorAsync(Visitors visitor)
        {
            _context.Visitors.Add(visitor);
            await _context.SaveChangesAsync();
            return visitor;
        }

        public async Task UpdateVisitorAsync(long id, Visitors visitor)
        {
            if (id != visitor.Id)
            {
                throw new ArgumentException("Id mismatch");
            }

            _context.Entry(visitor).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteVisitorAsync(long id)
        {
            var visitor = await _context.Visitors.FindAsync(id);
            if (visitor == null)
            {
                throw new KeyNotFoundException($"Visitor with id {id} not found");
            }

            _context.Visitors.Remove(visitor);
            await _context.SaveChangesAsync();
        }

        public async Task<Visitors> GetVisitorByMobileNoAsync(string mobileNo)
        {
            return await _context.Visitors.FirstOrDefaultAsync(v => v.MobileNo == mobileNo);
        }
        public async Task<VisitorDto> GetVisitorByMobileNoWithLastVisitAsync(string mobileNo)
        {
            var visitor = await _context.Visitors
                .AsNoTracking() // Ensure no tracking for performance
                .FirstOrDefaultAsync(v => v.MobileNo == mobileNo);

            if (visitor == null)
            {
                return null;
            }

            // Map the visitor entity to VisitorDto
            var visitorDto = _mapper.Map<VisitorDto>(visitor);

            // Fetch the latest visitor log for the visitor
            var latestVisitorLog = await _context.VisitorLogs
                .AsNoTracking() // Ensure no tracking for performance
                .Where(vl => vl.VisitorId == visitor.Id)
                .OrderByDescending(vl => vl.CreatedOn)
                .FirstOrDefaultAsync();

            // Map the latest visitor log to VisitorLogDto and include it in VisitorDto
            if (latestVisitorLog != null)
            {
                visitorDto.LastVisitorLog = _mapper.Map<VisitorLogDto>(latestVisitorLog);
            }

            // Return the mapped VisitorDto
            return visitorDto;
        }
    }
}