using Maxsociety.Models;

namespace Maxsociety.Services
{
    public interface IVisitorsService
    {
        Task<IEnumerable<Visitors>> GetVisitorsAsync();
        Task<Visitors> GetVisitorByIdAsync(long id);
        Task<Visitors> AddVisitorAsync(Visitors visitor);
        Task UpdateVisitorAsync(long id, Visitors visitor);
        Task DeleteVisitorAsync(long id);
    }
}

