using Maxsociety.Data;
using Maxsociety.Models;
using Microsoft.EntityFrameworkCore;

namespace Maxsociety.Services 
{
public class VisitorsService : IVisitorsService
{
    private readonly ApplicationDbContext _context;

    public VisitorsService(ApplicationDbContext context)
    {
        _context = context;
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
}


}