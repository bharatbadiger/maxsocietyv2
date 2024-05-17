using Maxsociety.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Maxsociety.Services
{
    public interface IVisitorLogsService
    {
        Task<IEnumerable<VisitorLogs>> GetVisitorLogsAsync();
        Task<VisitorLogs> GetVisitorLogByIdAsync(long id);
        Task<VisitorLogs> AddVisitorLogAsync(VisitorLogs visitorLog);
        Task UpdateVisitorLogAsync(long id, VisitorLogs visitorLog);
        Task DeleteVisitorLogAsync(long id);
        Task<IEnumerable<VisitorLogs>> GetVisitorLogsByVisitorIdAsync(long visitorId);
    }
}
